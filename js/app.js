// MODULES 
// api key hidden from version control, api-key.js exports two-piece module.

import { API_KEY_START, API_KEY_APPID } from "./api-key.js"
//const key = require("api-jey.js")
import fetch from "node-fetch"
//const readline = require('readline')
import readline from "readline"
const read = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

// OUTPUT, prints a formatted snippet from the JSON
const printFormatJSON = (json, city_name) => {
  console.log(
    `Weather in ${city_name}:
      \t${json.weather[0].main}
      \tTemperature: ${json.main.temp} Celsius
      \tHumidity: ${json.main.humidity} %`
  )
}

// FETCH, requests the data from API in JSON format
// ,then outputs some.
const getWeather = async (city_name) => {
  fetch(`${API_KEY_START}${city_name}${API_KEY_APPID}`)
    .then(res => res.json())
    .then(json => printFormatJSON(json, city_name))
    .catch(err => {
      console.log(`${city_name} is not a valid search argument.\n${err}`)
    })
}


// the readline module reads user input from cli and makes the API call.
read.question('SEND LOCATION: ', (answer) => {
  getWeather(answer)
  read.close()
})
