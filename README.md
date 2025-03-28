Projekt: Zarządzanie Kontenerami i Statkami

Opis projektu:
Projekt symuluje system zarządzania kontenerami transportowymi oraz ich operacjami na statkach. 
Obejmuje różne typy kontenerów, które mogą przechowywać różne towary, w tym ciecze, gazy oraz 
produkty wymagające chłodzenia. Statki mogą załadowywać, usuwać, przenosić i zastępować kontenery, 
a system uwzględnia ograniczenia dotyczące masy i ilości kontenerów.

Technologie:
Język programowania: C#
Wersja .NET: .NET 7/8

Struktura kodu
1. Container (klasa abstrakcyjna)
Podstawowa klasa reprezentująca kontener.
  Pola: unikalny numer seryjny, maksymalne i aktualne obciążenie.
  Metody:
  - Load(double weight): dodaje ładunek do kontenera.
  - Unload(): opróżnia kontener.
  - PrintInfo(): wyświetla informacje o kontenerze.

2. LiquidContainer
Dziedziczy po Container, obsługuje ciecze.
  Pola: IsHazardous (czy ciecz jest niebezpieczna).
  Zmodyfikowana metoda Load(weight) – ograniczenie do 50% dla substancji niebezpiecznych i 90% dla innych.
  NotifyHazard(message): ostrzega o zagrożeniu.

3. GasContainer
Dziedziczy po Container, obsługuje gazy.
  Pola: Pressure (ciśnienie gazu).
  Zmodyfikowana metoda Unload() – pozostawia 5% gazu.
  NotifyHazard(message): ostrzega o zagrożeniu.

4. RefrigeratedContainer
Dziedziczy po Container, przechowuje produkty wymagające chłodzenia.
  Pola: ProductType, RequiredTemperature, CurrentTemperature.
  Dodatkowa metoda Load(weight, productType) – sprawdza typ produktu i kontroluje temperaturę.
  PrintInfo(): rozszerzona o wyświetlanie temperatury i typu produktu.

5. Ship
Reprezentuje statek przewożący kontenery.
  Pola: nazwa, maksymalna prędkość, liczba kontenerów, maksymalna waga, lista kontenerów.
  Metody:
  - LoadContainer(container), LoadContainers(list), RemoveContainer(serialNumber),
    ReplaceContainer(oldSerialNumber, newContainer), TransferContainer(targetShip, serialNumber).
  - PrintShipInfo(): wypisuje informacje o statku.
  - PrintAllContainers(): wypisuje informacje o kontenerach na statku.

6. Klasa Program (Testowanie funkcjonalności)
  Tworzy kilka obiektów Ship i Container.
  Dodaje kontenery do statków.
  Testuje operacje takie jak:
  Załadunek i rozładunek kontenerów.
  Sprawdzenie limitów wagowych.
  Powiadomienia o zagrożeniach (NotifyHazard).
  Usuwanie i zastępowanie kontenerów.
  Przenoszenie kontenerów między statkami.
  Wyświetla informacje o statkach i ich kontenerach.
