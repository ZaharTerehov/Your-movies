import axios from "axios";

export const BaseUrl = 'https://localhost:7227/api/';

export const EndPoints = {
    ganre: 'Ganre/'
}

export const EndPointsGanre = {
    getAll: 'Ganre/',
    getById: 'Ganre/',
    create: 'Ganre/',
    delete: 'Ganre/',
    update: 'Ganre/',
}

export const EndPointsCountry = {
    getAll: 'Country/',
    getById: 'Country/',
    create: 'Country/',
    delete: 'Country/',
    update: 'Country/',
}

export const EndPointsTypeCinema = {
    getAll: 'TypeCinema/',
    getById: 'TypeCinema/',
    create: 'TypeCinema/',
    delete: 'TypeCinema/',
    update: 'TypeCinema/',
}

export const EndPointsPerson = {
    getAll: 'Person/',
    getById: 'Person/',
    create: 'Person/',
    delete: 'Person/',
    update: 'Person/',
}

export const EndPointsProductionCompany = {
    getAll: 'ProductionCompany/',
    getById: 'ProductionCompany/',
    create: 'ProductionCompany/',
    delete: 'ProductionCompany/',
    update: 'ProductionCompany/',
}

export const EndPointsDepartment = {
    getAll: 'Department/',
    getById: 'Department/',
    create: 'Department/',
    delete: 'Department/',
    update: 'Department/',
}

export const EndPointsAgeRating = {
    getAll: 'AgeRating/',
    getById: 'AgeRating/',
    create: 'AgeRating/',
    delete: 'AgeRating/',
    update: 'AgeRating/',
}

export const EndPointsCinemaCast = {
    getAll: 'CinemaCast/',
    getById: 'CinemaCast/',
    create: 'CinemaCast/',
    delete: 'CinemaCast/',
    update: 'CinemaCast/',
}

export const EndPointsCinemaCrew = {
    getAll: 'CinemaCrew/',
    getById: 'CinemaCrew/',
    create: 'CinemaCrew/',
    delete: 'CinemaCrew/',
    update: 'CinemaCrew/',
}

export const EndPointsCinema = {
    getAll: 'Cinema/GetCinema/',
    getById: 'Cinema/GetCinema/',
    create: 'Cinema/AddCinema',
    delete: 'Cinema/DeleteCinema/',
    update: 'Cinema/UpdateCinema',
}

export const createApiEndpoint = endpoint => {
    let url = BaseUrl + endpoint;
    return {
        fetch: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        create: newRecord => axios.post(url, newRecord),
        update: (updatedRecord) => axios.put(url, updatedRecord),
        delete: id => axios.delete(url + id),
    }
}
