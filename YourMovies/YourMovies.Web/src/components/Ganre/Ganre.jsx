import React, { useState, useEffect, Fragment } from "react";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Container from 'react-bootstrap/Container';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { createApiEndpoint, EndPointsGanre } from "../../api";

const Ganre = () => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const[name, setName] = useState('');
  const[description, setDescription] = useState('');

  const[editId, setEditId] = useState('');
  const[editName, setEditName] = useState('');
  const[editDescription, setEditDescription] = useState('');

  const [data, setData] = useState([]);

  useEffect(() => {
    getData();
  }, []);

  const getData = () => {
    createApiEndpoint(EndPointsGanre.getAll).fetch()
    .then((result) => {
    setData(result.data)
    })
    .catch((error) => {
      console.log(error)
    })
  }

  const handleEdit = (id) => {
    handleShow();
    createApiEndpoint(EndPointsGanre.getById).fetchById(id)
    .then((result) => {
      setEditName(result.data.name);
      setEditDescription(result.data.description);
      setEditId(id);
    })
    .catch((error) => {
      console.log(error)
    })
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure to delete this ganre") == true) {
      createApiEndpoint(EndPointsGanre.delete).delete(id)
      .then((result) => {
        if(result.status === 200){
          toast.success('Ganre has been delete');
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
      "name": editName,
      "description": editDescription
    }

    createApiEndpoint(EndPointsGanre.update).update(data)
    .then((result) => {
      getData();
      clear();
      toast.success('Ganre has benn update');
    })
    .catch((error) => {
      toast.error(error);
    })

    handleClose();
  };

  const handleSave = () => {
    const data = {
      "name": name,
      "description": description
    }

    createApiEndpoint(EndPointsGanre.create).create(data)
    .then((result) => {
      getData();
      clear();
      toast.success('Ganre has been added');
    }).catch((error) => {
      toast.error(error);
    })
  };

  const clear = () => {
    setName('');
    setDescription('');
    setEditName('');
    setEditDescription('');
  }

  return (
    <Fragment>
      <div className="h1 text-center">Ganre</div>
      <ToastContainer/>
      <Container>
        <Row>
          <Col>
            <input type="text" className="form-control" placeholder="Enter name"
            value={name} onChange={(name) => setName(name.target.value)}/>
          </Col>
          <Col>
            <input type="text" className="form-control" placeholder="Enter description"
            value={description} onChange={(description) => setDescription(description.target.value)}/>
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
            <th>Name</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {data && data.length > 0
            ? data.map((item, index) => {
                return (
                  <tr key={index}>
                    <td>{index + 1}</td>
                    <td>{item.name}</td>
                    <td>{item.description}</td>
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
            <input type="text" className="form-control" placeholder="Enter name"
            value={editName} onChange={(name) => setEditName(name.target.value)}/>
          </Col>
          <Col>
            <input type="text" className="form-control" placeholder="Enter description"
            value={editDescription} onChange={(description) => setEditDescription(description.target.value)}/>
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

export default Ganre;
