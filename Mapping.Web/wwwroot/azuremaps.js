window.azureMapsFunctions = {
    init: function (id, key) {
        window._map = new atlas.Map(id, {
            center: [-77.4422, 37.5320],
            zoom: 13,
            authOptions: {
                authType: 'subscriptionKey',
                subscriptionKey: key
            }
        });
        window._map.events.add('ready', function () {
            var drawingToolbar = new atlas.control.DrawingToolbar({
                position: 'top-right',
                style: 'light',
                buttons: ['draw-polygon']
            });
            window._drawingManager = new atlas.drawing.DrawingManager(window._map, {
                toolbar: drawingToolbar,
                interactionType: 'hybrid',
                freehandInterval: 50 
            });
            var layers = window._drawingManager.getLayers();
            layers.polygonLayer.setOptions({ fillColor: 'green' });
            layers.polygonOutlineLayer.setOptions({ strokeColor: 'orange' });
            window._datasource = new atlas.source.DataSource('results');
            window._map.sources.add(window._datasource);
            window._map.layers.add(new atlas.layer.SymbolLayer(window._datasource, null, {
                textOptions: {
                    textField: ['to-string', ['get', 'label']]
                }
            }));
        });
        return true;
    },
    loadPolygons: function () {
        return JSON.stringify(window._drawingManager.getSource().toJson());
    },
    addPins: function (pins) {
        console.dir(pins);
        window._datasource.clear();
        for (var i = 0; i < pins.length; i++) {
            window._datasource.add(
                new atlas.data.Feature(
                    new atlas.data.Point([pins[i].lon, pins[i].lat]), {
                        label: pins[i].add
                    }
                )
            );
        }
        return true;
    }
};