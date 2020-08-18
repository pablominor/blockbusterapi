Cobertura de código:

Lo primero que se necesita realizar es agregar al proyecto de pruebas (puede ser tanto MSUnit como Xunit) el paquete nuget:
Install-Package coverlet.msbuild
Install-Package coverlet.collector

Como preparación del ambiente, será necesario instalar la herramienta dotnet-reportgenerator-globaltool:
dotnet tool install -g dotnet-reportgenerator-globaltool

*Con este comando, la herramienta se instalará globalmente. Si el desarrollador así lo desea, puede ser instalado localmente en el directorio de la solución.


Ejecutar las pruebas con recolección de cobertura de código:
Una vez posicionados en el directorio de la solución, el primer paso a realizar, 
será llamar el commando para la ejecución de la pruebas. 
A este comando se le deberá añadir los parámetros necesarios para la recolección 
de la cobertura y el directorio de salida donde poner estos resultados.

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput="./../TestResults/"

Generar el reporte html:
El siguiente paso consistirá en utilizar la herramienta de generación del reporte que instalamos para el dotnet seleccionando el archivo xml generado 
en el paso anterior y seleccionando que el reporte sea generado en html.

reportgenerator.exe "-reports:TestResults\coverage.cobertura.xml" "-targetdir:TestResults\html" "-reporttypes:HTML;"

Visualizar el reporte:
.\TestResults\html\index.htm


Para excluir namespaces:
Se utiliza %2c como coma(,) porque sino lo interpreta mal.
/p:Exclude="[*]BlockbusterApp.src.Infraestructure.*%2c[*]BlockbusterApp.src.Shared.*%2c[*]BlockbusterApp.src.UI.*%2c[*]BlockbusterApp.Program%2c[*]BlockbusterApp.Startup"


Comando completo para excluir todos los namespaces:
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput="./../TestResults/" /p:Exclude="[*]BlockbusterApp.src.Infraestructure.*%2c[*]BlockbusterApp.src.Shared.*%2c[*]BlockbusterApp.src.UI.*%2c[*]BlockbusterApp.Program%2c[*]BlockbusterApp.Startup"

reportgenerator.exe "-reports:TestResults\coverage.cobertura.xml" "-targetdir:TestResults\html" "-reporttypes:HTML;"

.\TestResults\html\index.htm

