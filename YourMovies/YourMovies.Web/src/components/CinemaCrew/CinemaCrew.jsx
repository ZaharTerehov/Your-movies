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
import { createApiEndpoint, EndPointsCinemaCrew, EndPointsPerson, EndPointsDepartment } from "../../api";

function CinemaCrew() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
  
    const[person, setPerson] = useState('');
    const[department, setDepartment] = useState('');
    const[job, setJob] = useState('');
  
    const[editId, setEditId] = useState('');
    const[editPerson, setEditPerson] = useState(0);
    const[editDepartment, setEditDepartment] = useState(0);  
    const[editJob, setEditJob] = useState('');
  
    const [data, setData] = useState([]);
    const [dataPerson, setDataPerson] = useState([]);
    const [dataDepartment, setDataDepartment] = useState([]);
  
    useEffect(() => {
        getData();
        getDataPerson();
        getDataDepartment();
    }, []);
  
    const getData = () => {
      createApiEndpoint(EndPointsCinemaCrew.getAll).fetch()  
      .then((result) => {
      setData(result.data)
      console.log(result.data)
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

    const getDataDepartment = () => {
      createApiEndpoint(EndPointsDepartment.getAll).fetch()
      .then((result) => {
        setDataDepartment(result.data)
        setDepartment(result.data[0].id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleEdit = (id) => {
      handleShow();
      createApiEndpoint(EndPointsCinemaCrew.getById).fetchById(id)
      .then((result) => {
        setEditPerson(result.data.personId);
        setEditDepartment(result.data.departmentId);
        setEditJob(result.data.job);
        setEditId(id);
      })
      .catch((error) => {
        console.log(error)
      })
    }
  
    const handleDelete = (id) => {
      if (window.confirm("Are you sure to delete this cinema crew") == true) {
        createApiEndpoint(EndPointsCinemaCrew.delete).delete(id)
        .then((result) => {
          if(result.status === 200){
            toast.success('Cinema crew has been delete');
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
        "departmentId": editDepartment,
        "job": editJob
      }
  
      createApiEndpoint(EndPointsCinemaCrew.update).update(data)
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema crew has been update');
      })
      .catch((error) => {
        toast.error(error);
      })
  
      handleClose();
    };
  
    const handleSave = () => {

      const data = {
        "personId": person,
        "departmentId": department,
        "job": job,
      }
  
      createApiEndpoint(EndPointsCinemaCrew.create).create(data) 
      .then((result) => {
        getData();
        clear();
        toast.success('Cinema crew has been added'); 
      }).catch((error) => {
        toast.error(error);
      })
    };
  
    const clear = () => {
      setPerson(dataPerson[0].id);
      setDepartment(dataDepartment[0].id);
      setJob('');
      setEditPerson('');
      setEditDepartment('');
      setEditJob('');
    }
  
    return (
      <Fragment>
        <div className="h1 text-center">Cinema crew</div>
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
            <Form.Select aria-label="Select department" onChange={(department) => setDepartment(department.target.value)}>
                {
                    dataDepartment && dataDepartment.length > 0
                    ? dataDepartment.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
            </Form.Select>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter job"
              value={job} onChange={(job) => setJob(job.target.value)}/>
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
              <th>Department</th>
              <th>Job</th>
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
                      <td>{item.department.name}</td>
                      <td>{item.job}</td>
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
              {/* <input type="text" className="form-control" placeholder="Enter department"
              value={editJob} onChange={(department) => setEditJob(department.target.value)}/> */}
              <Form.Select aria-label="Select department" value={editDepartment} onChange={(department) => setEditDepartment(department.target.value)}>
                {
                    dataDepartment && dataDepartment.length > 0
                    ? dataDepartment.map((item) => {
                        return (
                            <option value={item.id}>{item.name}</option>
                        );
                    })
                    : "Loading..."}
              </Form.Select>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Enter job"
              value={editJob} onChange={(job) => setJob(job.target.value)}/>
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

export default CinemaCrew
