from fastapi import FastAPI
from data_generator import get_raw_data

app = FastAPI()


@app.get('/')
async def home():
    data = get_raw_data()
    return {'Частота импульса ': f'{data["pulse_frequency"]}Гц',
            'Температура на входе в реактор ': f'{data["reactor_inlet_temperature"]}\u00b0C',
            'Температура на выходе из реактора ': f'{data["reactor_outlet_temperature"]}\u00b0C',
            'Давление теплоносителя ': f'{data["coolant_pressure"]}Па',
            }


@app.get('/raw_data')
def rand():
    return get_raw_data()
