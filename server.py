from flask import Flask
from flask import request
app = Flask(__name__)

@app.route('/')
def index():
  return 'Server Works!'
  
@app.route('/greet')
def say_hello():
  return 'Hello from Server'


@app.route('/example', methods=['POST'])
def example():
    request_data = request.get_json()
    first_name = request_data["FirstName"]
    id = request_data["Id"]
    
    response = app.response_class(
        response='{"Id":1,"FirstName":"Isaac","Secret":"Hi, Example."}',
        status=200,
        mimetype='application/json'
    )

    return response