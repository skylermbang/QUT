class Catg:
    def __init__(self, name, description):
        self.name = name
        self.description = description

    def get_city_details(self):
        return str(self)

    def __repr__(self):
        str = "name: {}, description: {} \n"
        str = str.format(self.name, self.description)
        return str
