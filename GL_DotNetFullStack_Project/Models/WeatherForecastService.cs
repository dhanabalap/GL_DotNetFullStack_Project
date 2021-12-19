namespace GL_DotNetFullStack_Project.Models
{
    public class WeatherForecastService :IWeatherForecastService
    {
        public WeatherForecast Get()
        {
            return new WeatherForecast
            {
                Summary = nameof(WeatherForecast)
            };
        }
    }
}
