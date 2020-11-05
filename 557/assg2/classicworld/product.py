from .catg import Catg


class Product:
    def __init__(self, modelName, maker, productionYear, description, seller, price):
        self.modelName = modelName
        self.maker = maker
        self.productionYear = productionYear
        self.description = description
        self.seller = seller
        self.price = price

    def get_product_details(self):
        return str(self)

    def __repr__(self):
        str = "modelName: {}, maker:{},productionYear:{} description: {}, seller: {} , price:{}\n"
        str = str.format(self.modelName, self.maker,
                         self.productionYear, self.description, self.seller, self.price)
        return str
