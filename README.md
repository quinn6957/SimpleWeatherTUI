# ☀️ Simple Terminal Weather App

A lightweight and user-friendly command-line interface (CLI) application that fetches and displays current weather information for a specified location. Get your weather updates quickly without leaving your terminal\!

## ✨ Features

  * **Current Weather:** Displays temperature, humidity, wind speed, and a brief description of current conditions.
  * **Location Search:** Easily search for weather in any city or region worldwide.
  * **Minimalist Output:** Clean and concise display, perfect for terminal use.
  * **Cross-Platform:** Runs on any operating system with .NET 9 installed.

## 🚀 Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

You'll need .NET 9 installed on your system. You can download it from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).

This application also requires an API key from a weather service. This project uses OpenWeatherMap, but if you're feeling adventurous, you can change the code to make it your own API.

1.  Go to [OpenWeatherMap](https://openweathermap.org/) and create a free account.
2.  Once logged in, navigate to the "API keys" section to generate your key.

### Installation

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/QSDevl/SimpleWeatherTUI.git
    cd SimpleWeatherTUI
    ```

2.  **Install dependencies:**

    ```bash
    dotnet restore
    ```

3.  **Configure your API Key:**

    Create a file named `.env` in the root directory of the project and add your OpenWeatherMap API key:

    ```
    OPENWEATHER_API_KEY=YOUR_API_KEY_HERE
    ```

    (Replace `YOUR_API_KEY_HERE` with the actual API key you obtained from OpenWeatherMap.)

## ⚙️ Usage

To get the weather for a specific city, run the script with the city name as an argument:

```bash
python weather_app.py "New York"
```

You can also specify a country code for more precise results (e.g., for cities with the same name in different countries):

```bash
/opt/ "London, UK"
```

### Example Output

```
Weather in London, UK:
Temperature: 15.0°C
Humidity: 80%
Wind Speed: 5.2 m/s
Conditions: Clouds
```

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📧 Contact

Your Name - your.email@example.com

Project Link: [https://github.com/your-username/simple-weather-app](https://www.google.com/search?q=https://github.com/your-username/simple-weather-app)