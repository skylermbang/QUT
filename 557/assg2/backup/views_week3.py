from flask import Blueprint, render_template, url_for, request, session, flash
from .models import Catg, Product, Order
from datetime import datetime
from .forms import CheckoutForm


AmericanMuscle = Catg(1, 'AmericanMuscle',
                      '60s American Muscle', 'AmericanMuscle.jpg')

JDM = Catg(2, 'JDM', 'Japanese Domestict Market Vechicle', 'JDM.jpg')

Europian = Catg(3, 'Europian', 'Europian Luxury ', 'Europian.jpg')

Other = Catg(4, 'Other', 'Others such as handmade ...etc', 'Other.jpg')

Mustang = Product(1, 'Mustang', 'FORD', '1969',
                  "The best mustang", "Skyler", AmericanMuscle, 50000.00, '69mustang.jpg')


Camaro = Product(2, 'Camaro', 'CHEVORLET', '1967',
                 "Betteer than Mustang", "Skyler", AmericanMuscle, 37000.00, 'camaro.jpg')


GTR = Product(3, 'GTR', 'NISSAN', '1990',
                 "The GTR", "Scarlett", JDM, 47000.00, 'GTR.jpg')


NSX = Product(4, 'NSX', 'HONDA', '1991',
                 "Japanese FERRARI", "Joey", JDM, 67000.00, 'NSX.jpg')


Targa = Product(5, 'Targa', 'PORSCHE', '1980',
                "Real history", "Skyler", Europian, 87000.00, 'targa.jpg')


catgs = [AmericanMuscle, JDM, Europian, Other]

products = [Mustang, Camaro, GTR, NSX, Targa]


order1 = Order(1, False, '', '', '', '',
               datetime.now(), [Mustang, Camaro], Mustang.price+Camaro.price)

order2 = Order(2, False, '', '', '', '',
               datetime.now(), Camaro, Camaro.price)

orders = [order1, order2]


bp = Blueprint('main', __name__)


@bp.route('/')
def index():
    return render_template('index.html', catgs=catgs)


'''
@bp.route('/checkout/', methods=['POST', 'GET'])
def checkout():

    # print form paramenters sent using GET
    print('Firstname: {}\nSurname: {}\nPhone: {}'
          .format(request.values.get('firstname'), request.values.get('surname'), request.values.get('phone')))

    # put form firstname into session
    session['firstname'] = request.values.get('firstname')

    return render_template('checkout.html')
'''


@bp.route('/products/<int:category_id>/')
def catgproducts(category_id):
    catgproducts = []
    # create list of products for this city
    for product in products:
        if product.catg.id == category_id:
            catgproducts.append(product)
    return render_template('catgproduct.html', products=catgproducts)


@bp.route('/order/', methods=['POST', 'GET'])
def order():

    product_id = request.args.get('product_id')
    # is this a new order?
    if 'order_id'not in session:
        # arbitry, we could set either order 1 or order 2
        session['order_id'] = 1

    # retrieve correct order object
    for x in orders:
        if int(x.id) == int(session['order_id']):
            order = x
    # are we adding an item? - will be implemented later with DB
    if product_id:
        print('user requested to add product id = {}'.format(product_id))

    return render_template('order.html', order=order, totalprice=order.total_cost)


@bp.route('/deleteorder/')
def deleteorder():
    if 'order_id' in session:
        del session['order_id']
    return render_template('index.html')


@bp.route('/deleteorderitem/', methods=['POST'])
def deleteorderitem():
    print('User wants to delete product with id={}'.format(request.form['id']))
    return render_template('index.html')


@bp.route('/checkout/', methods=['POST', 'GET'])
def checkout():
    form = CheckoutForm()
    if 'order_id' in session:

        # retrieve correct order object
        for x in orders:
            if int(x.id) == int(session['order_id']):
                order = x

        if form.validate_on_submit():
            order.status = True
            order.firstname = form.firstname.data
            order.surname = form.surname.data
            order.email = form.email.data
            order.phone = form.phone.data
            print(order)
            flash('Thank you for your information')

    return render_template('checkout.html', form=form)
