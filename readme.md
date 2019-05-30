# Azure Maps & Azure Search Demo

This demo web application illustrates using Azure Maps to draw a polygon and then searching over a result set of [GeoJSON](http://geojson.io) points for results that intersect the polygon.

## Deploy

[![Deploy ARM Template](https://gist.githubusercontent.com/seesharprun/84d850d524f66c6429e383d99929771c/raw/4a4f34f9462a522a89a0635b492a13a84f9fe77f/azure-button-small.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fgithub.com%2Fseesharprun%2FMappingDemo%2Fraw%2Fmaster%2Fazuredeploy.json)

[View the ARM template](azuredeploy.json)

## Components

- [Azure Search](https://docs.microsoft.com/azure/search/) account 

- [Azure Container Instance](https://docs.microsoft.com/azure/container-instances/) running a console application that populates Azure Search with address in Richmond, VA

- [Azure Web App](https://docs.microsoft.com/azure/app-service-web) running a [Blazor](https://docs.microsoft.com/aspnet/core/blazor/) web application with the [Azure Maps](https://docs.microsoft.com/azure/azure-maps/) JavaScript web control


## Tips  

- To get started, click the **Load Map** button  

- Then click the **Polygon** button on the map toolbar  

- Use the ``Esc`` key to cancel drawing  

- Use the ``F`` key or ``click`` to add a point  

- Use the ``C`` key or ``double-click`` to complete a polygon.