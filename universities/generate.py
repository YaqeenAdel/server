from dataclasses import dataclass
import typing
import pycountry
import requests
from bs4 import BeautifulSoup
import csv

# Define the base URL for the university search website
base_url = "http://univ.cc/search.php?dom="
town_url = "http://univ.cc/search.php?town="

@dataclass
class Location:
    country_code: str
    state_code: str = None
    state_name: str = None
    town_code: str = None
    town_name: str = None

@dataclass
class University:
    location: Location
    name: str

# Function to extract universities from a page
def extract_universities(url: str) -> typing.List[str]:
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')
    universities = []
    
    # Extract universities and add to the list
    university_list = soup.find_all('li')
    for university in university_list:
        universities.append(university.text.strip())
    
    return universities

def extract_towns(l: Location, url: str) -> typing.List[Location]:
    response = requests.get(url)
    soup = BeautifulSoup(response.text, 'html.parser')
    locations = []
    
    # Extract country or state/town name from the header
    towns = soup.find_all('option')
    # print(f"Location:{location}")
    
    for town in towns:
        town_name = town.text.strip()
        last_index = town_name.rfind(' ')
        if last_index > -1:
            town_name = town_name[:last_index]
        locations.append(Location(l.country_code, l.state_code, l.state_name, town['value'], town_name))
    
    return locations

def get_all_locations() -> typing.List[Location]:
    # List of countries and states
    locations = [Location(country.alpha_2.lower()) for country in pycountry.countries]
    locations.remove(Location('us'))

    extracted_locations = []
    for location in locations:
        url = base_url + (location.country_code if not location.state_code else f"edu_{location.state_code}")
        print("extracting towns from", url)
        extracted_locations.extend(extract_towns(location, url))

    states = pycountry.subdivisions.get(country_code='US')
    extracted_locations.extend([Location("us", state.code.lower()[-2:]) for state in states])
    return extracted_locations

def write_locations(locations: typing.List[Location]):
    # Create a CSV file to write the data
    with open('locations.csv', 'w', newline='') as csvfile:
        csv_writer = csv.writer(csvfile)
        csv_writer.writerow(["Country", "State Code", "State Name", "Town Code", "Town Name"])

        for location in locations:
            # for location, university in universities:
            csv_writer.writerow([location.country_code, location.state_code, location.state_name, location.town_code, location.town_name])

        # print(extracted_locations)

    print("Wrote to locations.csv")

def read_locations() -> typing.List[Location]:
    locations = []
    with open('locations.csv', newline='') as csvfile:
        csv_reader = csv.reader(csvfile)
        next(csv_reader)
        for row in csv_reader:
            locations.append(Location(row[0], row[1], row[2], row[3], row[4]))
    return locations

def get_universities(locations: typing.List[Location]) -> typing.List[University]:
    universities = []
    for location in locations:
        if location.town_code:
            url = town_url + location.town_code
        elif location.state_code:
            url = base_url + f"edu_{location.state_code}"
        else:
            continue
        print("extracting unis from", url)
        unis = extract_universities(url=url)
        for uni in unis:
            universities.append(University(location, uni))
    return universities

def write_universities(universities: typing.List[University]):
    with open('universities.csv', 'w', newline='') as csvfile:
        csv_writer = csv.writer(csvfile)
        csv_writer.writerow(["Country", "State Code", "State Name", "Town Code", "Town Name", "University"])
        for uni in universities:
            csv_writer.writerow([uni.location.country_code, uni.location.state_code, uni.location.state_name, uni.location.town_code, uni.location.town_name, uni.name])

    print("Data has been collected and saved to universities.csv.")

def write_all():
    extracted_locations = get_all_locations()
    write_locations(extracted_locations)
    universities = get_universities(extracted_locations)
    write_universities(universities)

if __name__ == "__main__":
    # write_all()
    
    locations = read_locations()
    print(f"loaded {len(locations)} locations")
    universities = get_universities(locations)
    print(f"got {len(universities)} universities")
    write_universities(universities)