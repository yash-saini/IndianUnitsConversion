# Indian Units Conversion

![Indian Units Conversion](https://img.shields.io/badge/Indian%20Units%20Conversion-1.0.0-brightgreen)

A comprehensive web-based conversion utility built with Blazor WebAssembly and .NET 8 that focuses on Indian and international units of measurement.

## 🌟 Features

- **Land Area Conversions**: Convert between hectare, square meter, acre, square kilometer, square foot/feet, square yard/yards, square guz, square bigha.
- **Weight Conversions**: Convert between kilogram, gram, pound, ounce, tonne, stone, milligram.
- **Currency Conversions**: Convert between USD, EUR, INR, GBP, JPY, AUD, CAD, CHF with real-time rates.
- **Gold Price Calculator**: Get current gold prices in different units (gram, tola, ounce, kilogram, pound, carat) and currencies.
- **Modern UI**: Responsive design.

## 📊 Architecture

The solution consists of two main projects:

### 1. ConversionAPI (.NET 8 Web API)
- Backend services handling all conversion logic
- RESTful endpoints for all conversion types
- External API integration for currency and gold price data

### 2. ConversionFrontend (Blazor WebAssembly)
- Client-side Blazor application
- Modern responsive UI with Bootstrap
- Seamless integration with the backend API

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later / Visual Studio Code

### Running the Application

1. Clone the repository:
   git clone https://github.com/yourusername/IndianUnitsConversion.git cd IndianUnitsConversion
   
2. Run the API:
   cd ConversionAPI dotnet run

   API will be available at `https://localhost:7001`

3. Run the Frontend (in a separate terminal):
   cd ConversionFrontend dotnet run

Frontend will be available at `https://localhost:7106`

## 🧪 Unit Converters

### Land Conversion
Supports conversions between:
- Hectare
- Square Meter
- Acre
- Square Kilometer
- Square Foot/Feet
- Square Yard/Yards
- Square Guz
- Square Bigha

### Weight Conversion
Supports conversions between:
- Kilogram
- Gram
- Pound
- Ounce
- Tonne
- Stone
- Milligram

### Currency Conversion
Supports conversions between:
- USD (US Dollar)
- EUR (Euro)
- INR (Indian Rupee)
- GBP (British Pound)
- JPY (Japanese Yen)
- AUD (Australian Dollar)
- CAD (Canadian Dollar)
- CHF (Swiss Franc)

### Gold Price Calculator
Supports weight units:
- Gram
- Tola (11.66g)
- Ounce (31.10g)
- Kilogram (1000g)
- Pound (453.59g)
- Carat (0.2g)

And currencies:
- INR (Indian Rupee)
- USD (US Dollar)
- EUR (Euro)
- GBP (British Pound)

## 🖼️ Screenshots

- Land Conversion

   <img width="1910" height="1005" alt="image" src="https://github.com/user-attachments/assets/0aed71e6-ebad-4d08-9302-cc936e185bfd" />
   
- Weight Conversion

  <img width="1898" height="989" alt="image" src="https://github.com/user-attachments/assets/a7800694-0bb0-4a10-b8b9-35e9390daae4" />
  
- Currency Conversion

  <img width="1901" height="951" alt="image" src="https://github.com/user-attachments/assets/2dd5ffc3-3824-40f0-a3b3-a2eec3534861" />
  
- Gold Prices Calculator

  <img width="1900" height="1004" alt="image" src="https://github.com/user-attachments/assets/138cce32-2370-4fec-a18d-613b7dea05d8" />

- API screen

  <img width="1920" height="1808" alt="image" src="https://github.com/user-attachments/assets/07c00035-0c04-450d-88bb-a258633399a3" />


## 🛠️ Technologies Used

**Backend**:
- ASP.NET Core 8
- C# 12
- RESTful API design
- Entity Framework Core with SQLite
- HttpClient for external API integration

**Frontend**:
- Blazor WebAssembly
- Bootstrap 5
- Bootstrap Icons
- Custom CSS

## 🔌 API Endpoints

| Endpoint | Method | Description | Request Body | Response |
|----------|--------|-------------|-------------|----------|
| **Land Conversion** |
| `/api/LandConversion/convert` | POST | Convert land area units | `{"value": 10, "fromUnit": "acre", "toUnit": "hectare"}` | `{"convertedValue": 4.04686, "fromUnit": "acre", "toUnit": "hectare", "landId": "guid"}` |
| `/api/LandConversion/units` | GET | Get supported land units | None | `["hectare", "square_meter", "acre", "square_kilometer", ...]` |
| `/api/LandConversion/history` | GET | Get land conversion history | None | Array of conversion records |
| **Weight Conversion** |
| `/api/WeightConversion/convert` | POST | Convert weight units | `{"value": 100, "fromUnit": "gram", "toUnit": "kilogram"}` | `{"convertedValue": 0.1, "fromUnit": "gram", "toUnit": "kilogram", "weightId": "guid"}` |
| `/api/WeightConversion/units` | GET | Get supported weight units | None | `["kilogram", "gram", "pound", "ounce", ...]` |
| `/api/WeightConversion/history` | GET | Get weight conversion history | None | Array of conversion records |
| **Currency Conversion** |
| `/api/CurrencyConversion/convert` | POST | Convert currency amounts | `{"amount": 100, "fromCurrency": "USD", "toCurrency": "EUR"}` | `{"convertedAmount": 85.20, "fromCurrency": "USD", "toCurrency": "EUR"}` |
| `/api/CurrencyConversion/currencies` | GET | Get supported currencies | None | `["USD", "EUR", "INR", "GBP", ...]` |
| `/api/CurrencyConversion/history` | GET | Get currency conversion history | None | Array of conversion records |
| **Gold Price Calculation** |
| `/api/GoldPriceConversion/calculate` | POST | Calculate gold prices | `{"weight": 10, "unit": "gram", "currency": "USD"}` | `{"pricePerGram": 63.25, "pricePerUnit": 63.25, "totalPrice": 632.50, "unit": "gram", "currency": "USD"}` |
| `/api/GoldPriceConversion/units` | GET | Get supported gold weight units | None | `["gram", "tola", "ounce", "kilogram", ...]` |
| `/api/GoldPriceConversion/currencies` | GET | Get supported gold price currencies | None | `["INR", "USD", "EUR", "GBP"]` |
| `/api/GoldPriceConversion/history` | GET | Get gold price calculation history | None | Array of conversion records |
| **Conversion History** |
| `/api/ConversionHistory` | GET | Get all conversion history | None | Array of all conversion records |
| `/api/ConversionHistory/types` | GET | Get all conversion types | None | `["Land", "Weight", "Currency", "Gold"]` |
| `/api/ConversionHistory/{type}` | GET | Get history for specific conversion type | None | Array of conversion records for specific type |

## 📋 Future Enhancements

- Add more Indian traditional units
- Add temperature conversion
- Adding unit tests
- Add volume conversion
- Add offline mode support
- Add historical conversion data
- Implement user accounts to save favorite conversions

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Contributors

- [Yash Saini](https://github.com/yash-saini)
   
   
