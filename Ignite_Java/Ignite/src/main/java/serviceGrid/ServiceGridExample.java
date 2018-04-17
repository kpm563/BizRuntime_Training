package serviceGrid;

import org.apache.ignite.Ignite;
import org.apache.ignite.Ignition;

public class ServiceGridExample {

    public static void main(String[] args) throws Exception {
        try (Ignite ignite = Ignition.start()) {

            // Deploying a single instance of the Weather Service 
            // in the whole cluster.
            ignite.services().deployClusterSingleton("WeatherService",
               new WeatherServiceImpl());

            // Requesting current weather for London.
            WeatherService service = ignite.services().service("WeatherService");

            String forecast = service.getCurrentTemperature("London", "UK");

            System.out.println("Weather forecast in London:" + forecast);
        }
    }
}