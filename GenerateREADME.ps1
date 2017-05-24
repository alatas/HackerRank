[xml]$doc = Get-Content ("$PSScriptRoot\HackerRank\Challenges\Challenges.xml")

[string] $out = @"
## HackerRank Solutions
My solutions to HackerRank challenges

---
### Included Challenges

"@


foreach ($category in $doc.challenges.challenge | 
    Group-Object Category -NoElement | 
    Sort-Object Name) {
  $out += "#### $($category.Name)`r`n"
  foreach ($subcategory in $doc.challenges.challenge | 
      Where-Object {$_.Category -eq $category.Name} | 
      Group-Object SubCategory -NoElement | 
      Sort-Object Name) {
    $out += "##### $($subcategory.Name)`r`n"
    foreach ($challenge in  $doc.challenges.challenge | 
        Where-Object {$_.Category -eq $category.Name} | 
        Where-Object {$_.SubCategory -eq $subcategory.Name} | 
        Sort-Object Score, Name) {
      $out += "- [x] $($challenge.Name) (Score: $($challenge.Score))`r`n"
    }
    $out += "`r`n"
  }
}

$out += @"
---
### Directory Structure

Item | Description
---- | -----------
UnitTest.vb | Unit tests main
Challenges\ | Root folder for challenges
Challenges\Challenges.xml | Definition file for challenges
Challenges\ChallengeId\ | Challenge folder
Challenges\ChallengeId\Code.vb | Challenge specific solution code
Challenges\ChallengeId\In\ | Challenge specific inputs
Challenges\ChallengeId\Out\ | Challenge specific expected outputs

---
### Version History

"@

foreach ($ver in $doc.challenges.challenge | 
    Group-Object Version | 
    Select-Object Name, @{Name = "Value"; Expression = {($_.Group | Foreach-Object {"[$($_.Name)]($($_.Link))"}) -join ", "}} | 
    Select-Object *, @{Name = "SortKey"; Expression = {[int]$_.Name}} | 
    Sort-Object SortKey -Descending) {
  $out += "- v$($ver.Name) added $($ver.Value)`r`n"
}

$out | Out-File "$PSScriptRoot\README.md" -Encoding utf8 -NoNewline