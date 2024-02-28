# Cyber Logic SearchV2 API Test Script

## Overview
This C# script is designed to test the functionality of the Cyber Logic SearchV2 API endpoint. It sends a POST request with specified parameters and validates the response. The script handles error cases gracefully and provides feedback on the API response.

## Dependencies
- .NET Core SDK (or .NET Framework) for compiling and running C# code.

## Setup Requirements
1. Install the .NET Core SDK or .NET Framework on your machine. from https://dotnet.microsoft.com/en-us/download/dotnet/5.0
2. Create a new C# project or add the script to an existing project.
3. Ensure proper configuration of your development environment.

## Usage
1. Insert your ApI Credentials here 
    ```bash
            string userName = "xxxxxxxxxx";
            string password = "xxxxxxxxxx";
    ```

2. Replace the placeholder values (`Location`, `dateFrom`,`dateTo`, `Rooms`) in the request parameters with actual values according to the API documentation.
3. Run the script.

    ```bash
    dotnet run
    ```
4. Review the output to verify the functionality of the API endpoint.



