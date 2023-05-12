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
import { createApiEndpoint, EndPointsCinemaCast, EndPointsPerson } from "../../api";

function CinemaCast() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
  
    const[person, setPerson] = useState('');
    const[cinema, setCinema] = useState('');
    const[characterName, setCharacterName] = useState('');
    const[castOrder, setCastOrder] = useState('');
  
    const[editId, setEditId] = useState('');
    const[editPerson, setEditPerson] = useState(0);
    const[editCinema, setEditCinema] = useState(0);
    const[editCharacterName, setEditCharacterName] = useState('');
    const[editCastOrder, setEditCastOrder] = useState('');
  
    const [data, setData] = useState([]);
    const [dataPerson, setDataPerson] = useState([]);
    const [dataCinema, setDataCinema] = useState([]);
  
    useEffect(() => {
        getData();
        getDataPerson();
    }, []);
  
    const getData = () => {
      createApiEndpoint(EndPointsCinemaCast.getAll).fetch() 
      .then((result) => {
      setData(result.data)
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const getDataPerson = () => {
      createApiEndpoint(EndPointsPerson.getAll).fetch()
      .then((result) => {
        setDataPerson(result.data)
        setPerson(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleEdit = (id) => {
      handleShow();
      createApiEndpoint(EndPointsCinemaCast.getById).fetchById(id)
      .then((result) => {
        setEditPerson(result.data.personId);
        setEditCharacterName(result.data.castOrder);
        setEditCastOrder(result.data.characterName);
        setEditId(id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleDelete = (id) => {
      if (window.confirm("Are you sure to delete this cinema cast") == true) {
        createApiEndpoint(EndPointsCinemaCast.delete).delete(id)
        .then((result) => {
          if(result.status === 200){
            toast.success('Cinema cast has been delete');
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
        "personId": editPerson,
        "castOrder": editCharacterName,
        "characterName": editCastOrder,
      }
  
      createApiEndpoint(EndPointsCinemaCast.update).update(data)
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema cast has been update');
      })
      .catch((error) => {
        toast.error(error);
      })
  
      handleClose();
    };
  
    const handleSave = () => {
      const data = {
        "personId": person,
        "characterName": characterName,
        "castOrder": castOrder,
      }
  
      createApiEndpoint(EndPointsCinemaCast.create).create(data)
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema cast has been added'); 
      }).catch((error) => {
        toast.error(error);
      })
    };
  
    const clear = () => {
      setPerson(dataPerson[0].id);
      setCharacterName('');
      setCastOrder('');
      setEditPerson('');
      setEditCharacterName('');
      setEditCastOrder('');
    }
  
    return (
      <Fragment>
        <div className="h1 text-center">Cinema cast</div>
        <ToastContainer/>
        <Container>
          <Row>
            <Col>
            <Form.Select aria-label="Select person" onChange={(person) => setPerson(person.target.value)}>
                {
                    dataPerson && dataPerson.length > 0
                    ? dataPerson.map((item) => {
                        return (
                            <option value={item.id}>{item.name} {item.surname}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter characterName"
              value={characterName} onChange={(characterName) => setCharacterName(characterName.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter castOrder"
              value={castOrder} onChange={(castOrder) => setCastOrder(castOrder.target.value)}/>
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
              <th>Person</th>
              <th>CharacterName</th>
              <th>CastOrder</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {data && data.length > 0
              ? data.map((item, index) => {
                  return (
                    <tr key={index}>
                      <td>{index + 1}</td>
                      <td>{item.person.name} {item.person.surname}</td>
                      <td>{item.characterName}</td>
                      <td>{item.castOrder}</td>
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
              {/* <input type="text" className="form-control" placeholder="Enter person"
              value={editPerson} onChange={(person) => setEditPerson(person.target.value)}/> */}

              <Form.Select aria-label="Select person" value={editPerson} onChange={(person) => setEditPerson(person.target.value)}>
                {
                    dataPerson && dataPerson.length > 0
                    ? dataPerson.map((item) => {
                        return (
                            <option value={item.id}>{item.name} {item.surname}</option>
                        );
                    })
                    : "Loading..."}
              </Form.Select>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter characterName"
              value={editCastOrder} onChange={(characterName) => setEditCastOrder(characterName.target.value)}/>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter castOrder"
              value={editCharacterName} onChange={(castOrder) => setEditCharacterName(castOrder.target.value)}/>
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

export default CinemaCast
