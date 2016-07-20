param(
    [Parameter(Mandatory=$true)][string]$Uri=""
)

Write-Progress -Activity "Challenge download starting" -Status "Downloading info" -PercentComplete 0

$WebId=$Uri -replace "https?\:\/\/.*?hackerrank.com\/challenges\/([0-9A-Za-z\-]*?)","$1"
if ($WebId -eq $Uri) {Throw "Uri is not valid: $($Uri)"}

$Id =[Regex]::Replace($WebId, '(^|\-)(.)', { param($m) $m.Value.ToUpperInvariant().Replace('-','') })

$model=Invoke-RestMethod -Method Get -Uri https://www.hackerrank.com/rest/contests/master/challenges/$WebId | Select -ExpandProperty model

$name=$model.name
$score=$model.max_score


Write-Progress -Activity "Downloading $name" -Status "Downloading Test Cases" -PercentComplete 15
New-Item $env:TEMP\$Id -ItemType Directory -Force -ErrorAction SilentlyContinue | Out-Null
Invoke-WebRequest -Uri https://www.hackerrank.com/rest/contests/master/challenges/$WebId/download_testcases -OutFile $env:TEMP\$Id\testcases.zip
Expand-Archive -Path $env:TEMP\$Id\testcases.zip -DestinationPath $env:TEMP\$Id\ -Force


Write-Progress -Activity "Downloading $name" -Status "Creating Folders" -PercentComplete 30
New-Item $PSScriptRoot\HackerRank\Challenges\$Id -ItemType Directory -Force | Out-Null
New-Item $PSScriptRoot\HackerRank\Challenges\$Id\In -ItemType Directory -Force | Out-Null
New-Item $PSScriptRoot\HackerRank\Challenges\$Id\Out -ItemType Directory -Force | Out-Null


Write-Progress -Activity "Downloading $name" -Status "Moving Test Cases" -PercentComplete 40
Copy-Item $env:TEMP\$Id\input\input00.txt $PSScriptRoot\HackerRank\Challenges\$Id\In\In0.txt -Force
Copy-Item $env:TEMP\$Id\output\output00.txt $PSScriptRoot\HackerRank\Challenges\$Id\Out\Out0.txt -Force


Write-Progress -Activity "Downloading $name" -Status "Adding to defs" -PercentComplete 70
[xml] $doc = Get-Content("$PSScriptRoot\HackerRank\Challenges\Challenges.xml")
$child = $doc.CreateElement("challenge")
$att1=$doc.CreateAttribute("Id")
$att1.Value=$Id
$child.Attributes.Append($att1)

$att2=$doc.CreateAttribute("Name")
$att2.Value=$name
$child.Attributes.Append($att2)

$att3=$doc.CreateAttribute("Link")
$att3.Value=$Uri
$child.Attributes.Append($att3)

$doc.DocumentElement.AppendChild($child)
$doc.Save("$PSScriptRoot\HackerRank\Challenges\Challenges.xml")

Write-Progress -Activity "Downloading $name" -Status "Adding code.vb" -PercentComplete 90

$code=@"
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

Write-Progress -Activity "Downloading $name" -Status "Completed" -Completed