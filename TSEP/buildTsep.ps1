function Get-ScriptDirectory {
    Split-Path -Parent $PSCommandPath
}

$version = 8.6;
$directoryPath = Get-ScriptDirectory
$manifestFile = $directoryPath+"\Lookup.xml"
$outputFile = $directoryPath + "\buildResult\Lookup_" +$version + ".tsep"
$logFile = $directoryPath + "\"
$args = "-i", $manifestFile, "-o", $outputFile 

Write-Output $directoryPath
Write-Output $manifestFile
Write-Output $outputFile
Write-Output $logFile 

$databaseProcess = Start-Process -NoNewWindow -FilePath "C:\TeklaStructures\2021.0\nt\bin\TeklaExtensionPackage.BatchBuilder.exe"-PassThru -Wait -ArgumentList  "-i", $manifestFile, "-o", $outputFile, "-v", $version
Write-Output $databaseProcess 
