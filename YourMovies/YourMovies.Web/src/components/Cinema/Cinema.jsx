import React, { useState, useEffect, Fragment } from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Form from 'react-bootstrap/Form';
import Modal from "react-bootstrap/Modal";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Container from 'react-bootstrap/Container';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { createApiEndpoint, EndPointsCinemaCrew, EndPointsPerson, EndPointsDepartment, EndPointsAgeRating, EndPointsTypeCinema, EndPointsProductionCompany, EndPointsGanre, EndPointsCountry, EndPointsCinemaCast, EndPointsCinema } from "../../api";

function Cinema() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
  
    const[ageRating, setAgeRating] = useState('');
    const[typeCinema, setTypeCinema] = useState('');
    const[ganre, setGanre] = useState('');
    const[country, setCountry] = useState('');
    const[productionCompany, setProductionCompany] = useState('');
    const[cinemaCast, setCinemaCast] = useState('');
    const[cinemaCrew, setCinemaCrew] = useState('');
    const[name, setName] = useState('');
    const[description, setDescription] = useState('');
    const[releaseDate, setReleaseDate] = useState('');
    const[mainImage, setMainImage] = useState('');
    const[filmBudget, setFilmBudget] = useState('');
      
    const[editId, setEditId] = useState('');
    const[editAgeRating, setEditAgeRating] = useState('');
    const[editTypeCinema, setEditTypeCinema] = useState('');
    const[editGanre, setEditGanre] = useState('');
    const[editCountry, setEditCountry] = useState('');
    const[editProductionCompany, setEditProductionCompany] = useState('');
    const[editCinemaCast, setEditCinemaCast] = useState('');
    const[editCinemaCrew, setEditCinemaCrew] = useState('');
    const[editName, setEditName] = useState('');
    const[editDescription, setEditDescription] = useState('');
    const[editReleaseDate, setEditReleaseDate] = useState('');
    const[editMainImage, setEditMainImage] = useState('');
    const[editFilmBudget, setEditFilmBudget] = useState('');

    // const[editPerson, setEditPerson] = useState(0);
    // const[editDepartment, setEditDepartment] = useState(0);  
    // const[editJob, setEditJob] = useState('');
  
    const[data, setData] = useState([]);

    const[dataAgeRating, setDataAgeRating] = useState([]);
    const[dataTypeCinema, setDataTypeCinema] = useState([]);
    const[dataGanre, setDataGanre] = useState([]);
    const[dataCountry, setDataCountry] = useState([]);
    const[dataProductionCompany, setDataProductionCompany] = useState([]);
    const[dataCinemaCast, setDataCinemaCast] = useState([]);
    const[dataCinemaCrew, setDataCinemaCrew] = useState([]);

    // const[dataPerson, setDataPerson] = useState([]);
    // const[dataDepartment, setDataDepartment] = useState([]);
  
    useEffect(() => {
        getData();
        getDataAgeRating();
        getDataTypeCinema();
        getDataGanre();
        getDataCountry();
        getDataProductionCompany();
        getDataCinemaCast();
        getDataCinemaCrew();
    }, []);
  
    const getData = () => {
      createApiEndpoint(EndPointsCinema.getAll).fetch()  
      .then((result) => {
      setData(result.data)
      console.log(result.data)
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const getDataAgeRating = () => {
      createApiEndpoint(EndPointsAgeRating.getAll).fetch()
      .then((result) => {
        setDataAgeRating(result.data)
        setAgeRating(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataTypeCinema = () => {
      createApiEndpoint(EndPointsTypeCinema.getAll).fetch()
      .then((result) => {
        setDataTypeCinema(result.data)
        setTypeCinema(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataGanre = () => {
      createApiEndpoint(EndPointsGanre.getAll).fetch()
      .then((result) => {
        setDataGanre(result.data)
        setGanre(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataCountry = () => {
      createApiEndpoint(EndPointsCountry.getAll).fetch()
      .then((result) => {
        setDataCountry(result.data)
        setCountry(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataProductionCompany = () => {
      createApiEndpoint(EndPointsProductionCompany.getAll).fetch()
      .then((result) => {
        setDataProductionCompany(result.data)
        setProductionCompany(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataCinemaCast = () => {
      createApiEndpoint(EndPointsCinemaCast.getAll).fetch()
      .then((result) => {
        setDataCinemaCast(result.data)
        setCinemaCast(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }

    const getDataCinemaCrew = () => {
      createApiEndpoint(EndPointsCinemaCrew.getAll).fetch()
      .then((result) => {
        setDataCinemaCrew(result.data)
        setCinemaCrew(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleEdit = (id) => {
      handleShow();
      createApiEndpoint(EndPointsCinema.getById).fetchById(id)
      .then((result) => {
        setEditAgeRating(result.data.ageRatingId);
        setEditTypeCinema(result.data.typeCinemaId);
        setEditGanre(result.data.ganreId);
        setEditCountry(result.data.countryId);
        setEditProductionCompany(result.data.productionCompanyId);
        setEditCinemaCast(result.data.cinemaCastId);
        setEditCinemaCrew(result.data.cinemaCrewId);

        setEditId(id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleDelete = (id) => {
      if (window.confirm("Are you sure to delete this cinema") == true) {
        createApiEndpoint(EndPointsCinema.delete).delete(id)
        .then((result) => {
          if(result.status === 200){
            toast.success('Cinema has been delete');
            getData();
          }
        }).catch((error) => {
          toast.error(error);
        })
      }
    };
  
    const handleUpdate = () => { 
      const data = {
        "id": editId,
        "ageRatingId": editAgeRating,
        "typeCinemaId": editTypeCinema,
        "ganreId": editGanre,
        "countryId": editCountry,
        "productionCompanyId": editProductionCompany,
        "cinemaCastId": editCinemaCast,
        "cinemaCrewId": editCinemaCrew,
        "name": editName,
        "description": editDescription,
        "releaseDate": editReleaseDate,
        "mainImage": editMainImage,
        "filmBudget": editFilmBudget,
      }
  
      createApiEndpoint(EndPointsCinema.update).update(data)
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema has been update');
      })
      .catch((error) => {
        toast.error(error);
      })
  
      handleClose();
    };
  
    const handleSave = () => {

      const data = {
        "ageRatingId": ageRating,
        "typeCinemaId": typeCinema,
        "ganreId": ganre,
        "countryId": country,
        "productionCompanyId": productionCompany,
        "cinemaCastId": cinemaCast,
        "cinemaCrewId": cinemaCrew,
        "name": name,
        "description": description,
        "releaseDate": releaseDate,
        "mainImage": mainImage,
        "filmBudget": filmBudget,
      }
  
      createApiEndpoint(EndPointsCinema.create).create(data) 
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema has been added'); 
      }).catch((error) => {
        toast.error(error);
      })
    };
  
    const clear = () => {
      setAgeRating(dataAgeRating[0].id);
      setTypeCinema(dataTypeCinema[0].id);
      setGanre(dataGanre[0].id);
      setCountry(dataCountry[0].id);
      setProductionCompany(dataProductionCompany[0].id);
      setCinemaCast(dataCinemaCast[0].id);
      setCinemaCrew(dataCinemaCrew[0].id);
      setName('');
      setDescription('');
      setReleaseDate('');
      setMainImage('');
      setFilmBudget('');

      setEditAgeRating(dataAgeRating[0].id);
      setEditTypeCinema(dataTypeCinema[0].id);
      setEditGanre(dataGanre[0].id);
      setEditCountry(dataCountry[0].id);
      setEditProductionCompany(dataProductionCompany[0].id);
      setEditCinemaCast(dataCinemaCast[0].id);
      setEditCinemaCrew(dataCinemaCrew[0].id);
      setEditName('');
      setEditDescription('');
      setEditReleaseDate('');
      setEditMainImage('');
      setEditFilmBudget('');
    }
  
    return (
      <Fragment>
        <ToastContainer/>
        <Container>
          <Row>
            <Col>
            <Form.Select aria-label="Select age rating" onChange={(ageRating) => setAgeRating(ageRating.target.value)}>
                {
                    dataAgeRating && dataAgeRating.length > 0
                    ? dataAgeRating.map((item) => {
                        return (
                            <option value={item.id}>{item.viewAge} {item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select type cinema" onChange={(typeCinema) => setTypeCinema(typeCinema.target.value)}>
                {
                    dataTypeCinema && dataTypeCinema.length > 0
                    ? dataTypeCinema.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select ganre" onChange={(ganre) => setGanre(ganre.target.value)}>
                {
                    dataGanre && dataGanre.length > 0
                    ? dataGanre.map((item) => {
                        return (
                            <option value={item.id}>{item.description}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            </Row>
            <Row>
            <Col>
            <Form.Select aria-label="Select production company" onChange={(productionCompany) => setProductionCompany(productionCompany.target.value)}>
                {
                    dataProductionCompany && dataProductionCompany.length > 0
                    ? dataProductionCompany.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select cinema cast" onChange={(cinemaCast) => setCinemaCast(cinemaCast.target.value)}>
                {
                    dataCinemaCast && dataCinemaCast.length > 0
                    ? dataCinemaCast.map((item) => {
                        return (
                            <option value={item.id}>{item.characterName}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select cinema crew" onChange={(cinemaCrew) => setCinemaCrew(cinemaCrew.target.value)}>
                {
                    dataCinemaCrew && dataCinemaCrew.length > 0
                    ? dataCinemaCrew.map((item) => {
                        return (
                            <option value={item.id}>{item.job}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            </Row>
            <Row>
            <Col>
              <input type="text" className="form-control" placeholder="Enter name"
              value={editName} onChange={(name) => setName(name.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter description"
              value={editDescription} onChange={(description) => setDescription(description.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter release date"
              value={editReleaseDate} onChange={(releaseDate) => setReleaseDate(releaseDate.target.value)}/>
            </Col>
            </Row>
            <Row>
            <Col>
              <input type="text" className="form-control" placeholder="Enter main image"
              value={editMainImage} onChange={(mainImage) => setMainImage(mainImage.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter film budget"
              value={editFilmBudget} onChange={(filmBudget) => setFilmBudget(filmBudget.target.value)}/>
            </Col>
            <Col>
              <button className="btn btn-primary" onClick={() => handleSave()}>Submit</button>
            </Col>
            </Row>
        </Container>
        <br></br>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>#</th>
              <th>Age Rating</th>
              <th>Type Cinema</th>
              <th>Ganre</th>
              <th>Country</th>
              <th>Production Company</th>
              <th>Cinema Cast</th>
              <th>Cinema Crew</th>
              <th>Name</th>
              <th>Description</th>
              <th>Release Date</th>
              <th>Main Image</th>
              <th>Film Budget</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {data && data.length > 0
              ? data.map((item, index) => {
                  return (
                    <tr key={index}>
                      <td>{index + 1}</td>
                      <td>{item.ageRating.viewAge} {item.ageRating.name}</td>
                      <td>{item.typeCinema.name}</td>
                      <td>{item.ganre.name}</td>
                      <td>{item.country.name}</td>
                      <td>{item.productionCompany.name}</td>
                      <td>{item.cinemaCast.characterName}</td>
                      <td>{item.cinemaCrew.job}</td>
                      <td>{item.name}</td>
                      <td>{item.description}</td>
                      <td>{item.releaseDate}</td>
                      <td>{item.mainImage}</td>
                      <td>{item.filmBudget}</td>
                      <td colSpan={2}>
                        <button
                          className="btn btn-primary"
                          onClick={() => handleEdit(item.id)}
                        >
                          Edit
                        </button>{" "}
                        &nbsp;
                        <button
                          className="btn btn-danger"
                          onClick={() => handleDelete(item.id)}
                        >
                          Delete
                        </button>
                      </td>
                    </tr>
                  );
                })
              : "Loading..."}
          </tbody>
        </Table>
  
        <Modal show={show} onHide={handleClose} animation={false}>
          <Modal.Header closeButton>
            <Modal.Title>Modify / Update Ganre</Modal.Title>
          </Modal.Header>
          <Modal.Body>
          <Row>
          <Col>
            <Form.Select aria-label="Select age rating" value={editAgeRating} onChange={(editAgeRating) => setEditAgeRating(editAgeRating.target.value)}>
                {
                    dataAgeRating && dataAgeRating.length > 0
                    ? dataAgeRating.map((item) => {
                        return (
                            <option value={item.id}>{item.viewAge} {item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select type cinema" value={editTypeCinema} onChange={(editTypeCinema) => setEditTypeCinema(editTypeCinema.target.value)}>
                {
                    dataTypeCinema && dataTypeCinema.length > 0
                    ? dataTypeCinema.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select ganre" value={editGanre} onChange={(editGanre) => setEditGanre(editGanre.target.value)}>
                {
                    dataGanre && dataGanre.length > 0
                    ? dataGanre.map((item) => {
                        return (
                            <option value={item.id}>{item.description}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select production company" value={editProductionCompany} onChange={(editProductionCompany) => setEditProductionCompany(editProductionCompany.target.value)}>
                {
                    dataProductionCompany && dataProductionCompany.length > 0
                    ? dataProductionCompany.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select cinema cast" value={editCinemaCast} onChange={(editCinemaCast) => setEditCinemaCast(editCinemaCast.target.value)}>
                {
                    dataCinemaCast && dataCinemaCast.length > 0
                    ? dataCinemaCast.map((item) => {
                        return (
                            <option value={item.id}>{item.characterName}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
            <Form.Select aria-label="Select cinema crew" value={editCinemaCrew} onChange={(editCinemaCrew) => setEditCinemaCrew(editCinemaCrew.target.value)}>
                {
                    dataCinemaCrew && dataCinemaCrew.length > 0
                    ? dataCinemaCrew.map((item) => {
                        return (
                            <option value={item.id}>{item.job}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter name"
              value={editName} onChange={(name) => setEditName(name.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter description"
              value={editDescription} onChange={(description) => setEditDescription(description.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter release date"
              value={editReleaseDate} onChange={(releaseDate) => setEditReleaseDate(releaseDate.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter main image"
              value={editMainImage} onChange={(mainImage) => setEditMainImage(mainImage.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter film budget"
              value={editFilmBudget} onChange={(filmBudget) => setEditFilmBudget(filmBudget.target.value)}/>
            </Col>
          </Row>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
            <Button variant="primary" onClick={handleUpdate}>
              Save Changes
            </Button>
          </Modal.Footer>
        </Modal>
      </Fragment>
    );
};

export default Cinema
