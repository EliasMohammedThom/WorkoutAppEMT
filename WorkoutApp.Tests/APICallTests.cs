﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WorkoutApp.Tests
{
    public class APICallTests
    {
        [Fact]
        public async Task OnAPICallReturnExercise()
        {
            // Arrange
            string apiUrl = "https://api-ninjas.com/api/exercises?muscle=biceps";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";
            // Act
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
                // Assert
                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                    
                    Assert.True(responseMessage.IsSuccessStatusCode, $"API request failed with status code {responseMessage.StatusCode}");

                    string content = await responseMessage.Content.ReadAsStringAsync();
                    Assert.False(string.IsNullOrWhiteSpace(content), "No exercises returned.");

                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Assert.False(true, $"Exception thrown: {ex.Message}");
                }
            }

           
        }
        [Fact]
        public async Task OnAPICallReturnNutritonList()
        {
            // Arrange
            string foodType = "chicken";
            string apiUrl = $"https://api.api-ninjas.com/v1/nutrition?query={foodType}";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                    // Assert
                    Assert.True(responseMessage.IsSuccessStatusCode, $"API request failed with status code {responseMessage.StatusCode}");

                    string content = await responseMessage.Content.ReadAsStringAsync();
                    Assert.False(string.IsNullOrWhiteSpace(content), "No exercises returned.");

                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Assert.False(true, $"Exception thrown: {ex.Message}");
                }
            }

            // Act
        }
        [Fact]
        public async Task OnAPICallReturnCaloriesBurnedList()
        {
            // Arrange
            string activity = "hockey";
            string apiUrl = $"https://api.api-ninjas.com/v1/caloriesburned?activity={activity}";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                    // Assert
                    Assert.True(responseMessage.IsSuccessStatusCode, $"API request failed with status code {responseMessage.StatusCode}");

                    string content = await responseMessage.Content.ReadAsStringAsync();
                    Assert.False(string.IsNullOrWhiteSpace(content), "No exercises returned.");

                    Console.WriteLine(content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Assert.False(true, $"Exception thrown: {ex.Message}");
                }
            }
            // Act
        }
    }
}