from flask import Blueprint

bp = Blueprint('main', __name__)


@bp.route('/')
def index():
    return '<h1 style="color:red;> Hello world ! <h1>'


@bp.route('/secret')
def secret():
    return '<h1 style="color:blue;> Secret ! <h1>'
