#! /usr/bin/env node

// MODULES 
// PEPEGA
// api key hidden from version control, api-key.js exports two-piece module.
import { API_KEY_START, API_KEY_APPID } from "./api-key.js"
import fetch from "node-fetch"

// CITY NAME, get the "flag" the user input after call.
const args_length = process.argv.length

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
const getWeather = (city_name) => {
  fetch(`${API_KEY_START}${city_name}${API_KEY_APPID}`)
    .then(res => res.json())
    .then(json => printFormatJSON(json, city_name))
    .catch(err => {
      console.log(`${city_name} is not a valid search argument.\n${err}`)
    })
}

// Super janky, so we take the whole argv object and just use the last element, which hopefully is a city name.
// Intended to work as a flag but a sad one.
getWeather(process.argv[args_length - 1])
