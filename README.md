# FunFactAPI

FunFactAPI is a .NET 8.0 Web API that classifies numbers and provides interesting facts about them. The API can determine if a number is even, odd, prime, perfect, or an Armstrong number, and it fetches fun facts from the Numbers API.

## Features

- Classify numbers as even, odd, prime, perfect, or Armstrong.
- Calculate the digit sum of a number.
- Fetch fun facts about numbers from the Numbers API.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or later

### Installation

1. Clone the repository:
    <code>git clone [https://github.com/yourusername/FunFactAPI.git](https://github.com/Promise30/hngx-stage1-number-classification-api)</code>
2. Navigate to the project directory:
3. Restore the dependencies:
    <code>dotnet restore</code>


### Running the Application

1. Build the project:
2. Run the project:
    <code>dotnet run</code>


The API will be available at `https://localhost:5001` or `http://localhost:5000`.

### API Endpoints

#### Classify Number

- **URL:** `/api/classify-number`
- **Method:** `GET`
- **Query Parameter:** `number` (string, required)

**Response:**

- **Success:** Returns a JSON object with the classification and fun fact.
- **Error:** Returns a JSON object with an error message.

**Example Request:**
GET /api/classify-number?number=28

**Example Response:**
{ "number": 28, "is_prime": false, "is_perfect": true, "properties": ["even"], "digit_sum": 10, "fun_fact": "28 is the atomic number of nickel." }


## Project Structure

- **Controllers**
  - `ClassifierController.cs`: Contains the logic for classifying numbers and fetching fun facts.
- **Models**
  - `ErrorResponse.cs`: Model for error responses.
  - `SuccessResponse.cs`: Model for successful responses.
- **Program.cs**: Configures the application and services.
- 






