// MODULES 
// api key hidden from version control, api-key.js exports two-piece module.
const key = require("./api-key.js")
const fetch = require("node-fetch")
const readline = require('readline')
const read = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

// OUTPUT, prints a formatted snippet from the JSON
printFormatJSON = (json, city_name) => {
  console.log(
    `Weather in ${city_name}:
      \t${json.weather[0].main}
      \tTemperature: ${json.main.temp} Celsius
      \tHumidity: ${json.main.humidity} %`
  )
}

// FETCH, requests the data from API in JSON format
// ,then outputs some.
getWeather = async (type) => {
  if (type === 1) {
    read.question('SEND LOCATION: ', (city_name) => {
      fetch(`${key.API_KEY_START}${city_name}${key.API_KEY_APPID}`)
        .then(res => res.json())
        .then(json => printFormatJSON(json, city_name))
        .catch(err => {
          console.log(`${city_name} is not a valid search argument.\n${err}`)
        })
    })
  } else {
    console.log("Forecasts have not yet been implemented.")
    //read.question('SEND LOCATION: ', (city_name) => {
      //fetch(`${key.API_KEY_START}${city_name}${key.API_KEY_APPID}`)
        //.then(res => res.json())
        //.then(json => printFormatJSON(json, ))
    //})
  }
}

// the readline module reads user input from cli and makes the API call.
read.question('(1). Current\n(2). Forecast', (answer) => {
  if (answer === 1 || answer === 2) getWeather(answer)
  console.log('Wrong choice motherfucker.')
  read.close()
})
