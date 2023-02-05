function Get-ScriptDirectory {
    Split-Path -Parent $PSCommandPath
}

$scriptDirectory = Get-ScriptDirectory
$filePath = $scriptDirectory + "\..\Properties\AssemblyInfo.cs"

$file = Get-Content -Path $filePath
# Write-Output $file

$file -match 'assembly: AssemblyVersion'
If ($file -match 'assembly: AssemblyVersion'){
$Matches[0]}