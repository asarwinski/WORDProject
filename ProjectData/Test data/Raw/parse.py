from random import randint
if __name__ == "__main__":
    citys = []
    zipcodes = []
    states = []
    country = []

    infos = None

    with open('citys.txt', 'r') as reader:
        lines = reader.readlines()
        for line in lines:
            line = line.split(' ')
            for _ in range(int(line[-1])):
                citys.append(line[0])
                zipcodes.append(line[1])
                states.append(line[2])
                country.append("Polska")
        infos = list(zip(citys, states, country, zipcodes))
    with open('parsed_addresses.txt', 'w') as writer:
        writer.write('INSERT INTO dbo.Addresses (City, State, Country, Zipcode)\n')
        writer.write('Values\n')
        for _ in range(100):
            city, state, country, zipcode = infos[randint(0, len(infos)-1)]
            writer.write('(\'' + city + '\', \'' + state + '\', \'' + country + '\', \'' + zipcode + '\'),\n')
