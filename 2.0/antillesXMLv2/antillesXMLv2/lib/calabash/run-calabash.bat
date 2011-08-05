@ECHO OFF

if '%1 == ' goto no-params

if not exist %1 goto no-xpipe-file

set rootdir=.

REM if not exist C:\SAXON-license\saxon-license.lic goto no-saxon-lic

if not exist %rootdir%\lib\calabash\calabash.jar goto no-calabash-jar

if not exist %rootdir%\lib\saxon\saxon9.jar goto no-saxon-jar
if not exist %rootdir%\lib\saxon\saxon9-s9api.jar goto no-saxon-s9api-jar

set oldPath=%path%
set oldCLASSPATH=%CLASSPATH%

set CLASSPATH=.
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\calabash\calabash.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\saxon\saxon9.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\saxon\saxon9-s9api.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\saxon\saxon9sa.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\apache-commons-http-client\commons-httpclient-3.1.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\apache-commons-logging\commons-logging-1.1.1.jar
set CLASSPATH=%CLASSPATH%;%rootdir%\lib\apache-commons-codec\commons-codec-1.3.jar
set CLASSPATH=%CLASSPATH%;.;C:\SAXON-license\

java -classpath %CLASSPATH% -Dcom.xmlcalabash.phonehome=false com.xmlcalabash.drivers.Main -a %1  


set path=%oldPath%
set CLASSPATH=%oldCLASSPATH%

goto eof

:no-saxon-lic
    cls
    echo Oops! Do perform XML Schema validation you must have the SAXON license in your classpath.
    echo.
    goto eof

:no-params
    cls
    echo Oops! You need to run the batch file with 1 argument.
    echo Here's how to use it ...
    echo.
    echo Usage: "run-calabash <xpipe filename>"
    echo.
    goto eof

:no-xpipe-file
   cls
   echo Oops! %1 does not exist
   echo Most likely reason: mistyped filename
   echo Exiting ...
   echo.
   goto eof

:no-calabash-jar
   cls
   echo Oops! Missing this calabash file: %rootdir%%which_calabash%\lib\calabash.jar
   echo Most likely reason: calabash not installed in the correct directory
   echo Exiting ...
   goto eof

:no-saxon-jar
   cls
   echo Oops! Missing this saxon file: %rootdir%%which_saxon%\saxon9.jar
   echo Most likely reason: saxon not installed in the correct directory
   echo Exiting ...
   goto eof

:no-saxon-s9api-jar
   cls
   echo Oops! Missing this saxon file: %rootdir%%which_saxon%\saxon9-s9api.jar
   echo Most likely reason: saxon not installed in the correct directory
   echo Exiting ...
   goto eof

:eof

