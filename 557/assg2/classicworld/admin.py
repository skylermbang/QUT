
'''
CREATING A NEW DATABASE
-----------------------
Read explanation here: https://flask-sqlalchemy.palletsprojects.com/en/2.x/contexts/

In the terminal navigate to the project folder just above the miltontours package
Type 'python' to enter the python interpreter. You should see '>>>'
In python interpreter type the following (hitting enter after each line):
    from miltontours import db, create_app
    db.create_all(app=create_app())
The database should be created. Exit python interpreter by typing:
    quit()
Use DB Browser for SQLite to check that the structure is as expected before 
continuing.

ENTERING DATA INTO THE EMPTY DATABASE
-------------------------------------

# Option 1: Use DB Browser for SQLite
You can enter data directly into the cities or tours table by selecting it in
Browse Data and clicking the New Record button. The id field will be created
automatically. However be careful as you will get errors if you do not abide by
the expected field type and length. In particular the DateTime field must be of
the format: 2020-05-17 00:00:00.000000

# Option 2: Create a database seed function in an Admin Blueprint
See below. This blueprint needs to be enabled in __init__.py and then can be 
accessed via http://127.0.0.1:5000/admin/dbseed/
Database constraints mean that it can only be used on a fresh empty database
otherwise it will error. This blueprint should be removed (or commented out)
from the __init__.py after use.

Use DB Browser for SQLite to check that the data is as expected before 
continuing.
'''
from flask import Blueprint
from . import db
from .models import Catg, Product, Order
import datetime

bp = Blueprint('admin', __name__, url_prefix='/admin/')

# function to put some seed data in the database


@bp.route('/dbseed/')
def dbseed():
    c1 = Catg(name='AmericanMuscle', description='The American Msucle',
              image='AmericanMuscle.jpg')
    c2 = Catg(
        name='JDM', description='Japanese Domestic Market Vechicle', image='JDM.jpg')
    c3 = Catg(name='Europian', description='Europian Luxury',
              image='Europian.jpg')
    c4 = Catg(name='Other', description='Others like handmade ...etc',
              image='Other.jpg')
    try:
        db.session.add(c1)
        db.session.add(c2)
        db.session.add(c3)
        db.session.add(c4)
        db.session.commit()
    except:
        return 'There was an issue adding the cities in dbseed function'

    p1 = Product(modelName='Mustang', maker='FORD', productionYear='1969', description='The Best Mustang',
                 seller='Skyler', catg_id=c1.id, price=50000.00, image="69mustang.jpg")

    p2 = Product(modelName='Camaro', maker='CHEVORLET', productionYear='1967',
                 description='Better than Mustang', seller='Skyler', catg_id=c1.id, price=37000.00, image="camaro.jpg")
    p3 = Product(modelName='GTR', maker='NISSAN', productionYear='1990', description='The GTR',
                 seller='Scarlett', catg_id=c2.id, price=47000.00, image="GTR.jpg")
    p4 = Product(modelName='NSX', maker='HONDA', productionYear='1991',
                 description='Japanese FERRARI', seller='Tao', catg_id=c2.id, price=69000.00, image="NSX.jpg")

    p5 = Product(modelName='Targa', maker='PORSCHE', productionYear='1980', description='Sexy Beast',
                 seller='Scarlett', catg_id=c3.id, price=90000.00, image="targa.jpg")

    try:
        db.session.add(p1)
        db.session.add(p2)
        db.session.add(p3)
        db.session.add(p4)
        db.session.add(p5)

    except:
        return 'There was an issue adding a tour in dbseed function'

    return 'DATA LOADED'
