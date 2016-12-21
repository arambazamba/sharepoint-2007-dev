PATH C:\Program Files\Common Files\Microsoft Shared\web server extensions\12\BIN
stsadm.exe -o addSolution -filename c:\smartpartinstall\ReturnOfSmartPartv1_1.wsp
stsadm.exe -o deploySolution -name ReturnOfSmartPartv1_1.wsp -allcontenturls -local -allowGacDeployment
PAUSE