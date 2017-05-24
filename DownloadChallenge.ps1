param(
  [Parameter(Mandatory = $true)] [string]$Uri = ""
)

function Get-CaseDest {
  param(
    [string]$name,
    [string]$dest
  )
  $name = $name -replace "(output|input)(\d\d).txt", '$2'
  [int]$part = $name
  return "$PSScriptRoot\HackerRank\Challenges\$Id\$dest\$dest$part.txt"
}

Try {
  Write-Progress -Activity "Challenge download starting" -Status "Downloading info" -PercentComplete 0

  $WebId = $Uri -replace "https?\:\/\/(?:www\.)?hackerrank\.com\/challenges\/([0-9A-Za-z\-]*)(?:\?.*)?", '$1'
  If ($WebId -eq $Uri) { throw "Uri is not valid: $($Uri)" }

  $Uri = "https://www.hackerrank.com/challenges/$WebId"

  $Id = [regex]::Replace($WebId, '(^|\-)(.)', { param($m) $m.Value.ToUpperInvariant().Replace('-', '') })

  $model = Invoke-RestMethod -Method Get -Uri https://www.hackerrank.com/rest/contests/master/challenges/$WebId | Select -ExpandProperty model

  $name = $model.name
  $score = $model.max_score.ToString()
  $category = $model.track.track_name
  $subcategory = $model.track.name

  Write-Progress -Activity "Downloading $name" -Status "Downloading Test Cases" -PercentComplete 15
  New-Item $env:TEMP\$Id -ItemType Directory -Force -ErrorAction SilentlyContinue | Out-Null
  Invoke-WebRequest -Uri https://www.hackerrank.com/rest/contests/master/challenges/$WebId/download_testcases -OutFile $env:TEMP\$Id\testcases.zip
  Expand-Archive -Path $env:TEMP\$Id\testcases.zip -DestinationPath $env:TEMP\$Id\ -Force


  Write-Progress -Activity "Downloading $name" -Status "Creating Folders" -PercentComplete 30
  New-Item $PSScriptRoot\HackerRank\Challenges\$Id -ItemType Directory -Force | Out-Null
  New-Item $PSScriptRoot\HackerRank\Challenges\$Id\In -ItemType Directory -Force | Out-Null
  New-Item $PSScriptRoot\HackerRank\Challenges\$Id\Out -ItemType Directory -Force | Out-Null


  Write-Progress -Activity "Downloading $name" -Status "Moving Test Cases" -PercentComplete 40
  Get-ChildItem -Path $env:TEMP\$Id\input\ -Filter *.txt | % { $out = Get-CaseDest -Name $_.name -dest In; Copy-Item $_.FullName -Destination $out }
  Get-ChildItem -Path $env:TEMP\$Id\output\ -Filter *.txt | % { $out = Get-CaseDest -Name $_.name -dest Out; Copy-Item $_.FullName -Destination $out }

  Write-Progress -Activity "Downloading $name" -Status "Adding to defs" -PercentComplete 70

 
  [xml]$doc = Get-Content ("$PSScriptRoot\HackerRank\Challenges\Challenges.xml")
  If ($doc.SelectSingleNode("//challenge[@Id=$Id]") -eq $null) {
    $child = $doc.challenges.challenge[-1].clone()
    $child.Score = $score
    $child.Id = $Id
    $child.Name = $name
    $child.Link = $Uri
    $child.Category = $category
    $child.SubCategory = $subcategory

    $doc.DocumentElement.AppendChild($child)
    $doc.Save("$PSScriptRoot\HackerRank\Challenges\Challenges.xml")
  }

  Write-Progress -Activity "Downloading $name" -Status "Adding code.vb" -PercentComplete 90

  $code = @"
'$name
'$Uri
'Score $score
Imports System
Imports System.Collections.Generic

Module $Id
    Sub Main()

        Dim n As Integer = Console.ReadLine()
       
        '...
    End Sub
End Module
"@
  Set-Content -Path $PSScriptRoot\HackerRank\Challenges\$Id\Code.vb -Value $code

  Write-Progress -Activity "Downloading $name" -PercentComplete 100 -Status "Completed"
}
Catch {
  Write-Error $Error[0]
}
Finally {
  Write-Progress -Activity "Downloading $name" -Completed
  Start-Sleep 1
}
