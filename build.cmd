cls
@msbuild /nologo
@mstest /testcontainer:Jsoner.tests\bin\debug\jsoner.tests.dll /nologo /noisolation /usestderr /detail:errormessage
