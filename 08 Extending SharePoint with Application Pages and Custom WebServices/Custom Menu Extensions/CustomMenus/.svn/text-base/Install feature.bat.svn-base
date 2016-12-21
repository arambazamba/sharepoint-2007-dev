::
:: To customize this file, find and replace
:: a) "SampleFeature" with your own feature name  
:: b) "feature.xml" with the name of your feature.xml file
:: c) "elements.xml" with the name of your elements.xml file
:: d) "http://localhost" with the name of the site you wish to publish to

echo Copying the feature...
echo.
rd /s /q "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\SampleFeature"
mkdir "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\SampleFeature"

copy /Y feature.xml  "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\SampleFeature\"
copy /Y elements.xml "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\SampleFeature\"


echo.
echo Activating the feature...
echo.
pushd %programfiles%\common files\microsoft shared\web server extensions\12\bin
stsadm -o deactivatefeature -filename SampleFeature\feature.xml -url http://demo.develop.com/SiteDirectory/teamsite1
stsadm -o uninstallfeature -filename SampleFeature\feature.xml

rd /s /q "%CommonProgramFiles%\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\SampleFeature"

:: stsadm -o installfeature -filename SampleFeature\feature.xml -force
:: stsadm -o activatefeature -filename SampleFeature\feature.xml -url http://demo.develop.com/SiteDirectory/teamsite1


echo Doing an iisreset...
echo.
popd
iisreset
