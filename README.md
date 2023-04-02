# CryptoApp-NEC

# API con implementación de lado del cliente creada como parte de un proceso de selección
## Ejercicio Práctico 1 (C#)
Implementar una web API RESTful que:
1. Esté programada en C# (.NET)
2. Permita obtener las últimas cotizaciones de, por lo menos, cinco cryptomonedas.
• Deben estar incluidas: Bitcoin (BTC), Ethereum (ETH), Binance Coin (BNB), Tether (USDT), Cardano 
(ADA)
• El sitio deberá actualizar la información de la pantalla cada 5 segundos. (No tiene que hacer Postback)
3. Seleccionar una cryptomoneda, ingresar una cantidad y mostrar el monto final de la conversión a las 
cryptomonedas restantes.
El proyecto deberá:
• Estar subido a GitHub.
• Tener la API Key como un campo configurable (no hard-codeado en los consumos de API).
• Incluir cualquier comentario en el Readme.md del repositorio.
API a utilizar:
https://coinmarketcap.com/api/documentation/v1/
Se valorará positivamente:
• Uso de Angular.
• Manejo de errores.
• Utilizar Patrones de diseño


## Para su correcto funcionamiento se debe incluir la ApiKey como variable en el archivo appsettings.json, bajo el nombre de ApiKey
## Se utilizó el patrón Singleton para asegurar una única instancia de las implementaciones de las interfaces
## Implementación cliente realizada en Angular