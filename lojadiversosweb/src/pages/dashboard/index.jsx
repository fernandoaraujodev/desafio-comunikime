import React, {useState, useEffect} from "react";

import {Form, Button, Table, Card, Container} from 'react-bootstrap';
import Header from "../../components/header";

import './styles.css'

//toast
import { useToasts } from 'react-toast-notifications';

const Dashboard = () => {
    const {addToast} = useToasts();

    const [id, setId] = useState(0);
    const [name, setName] = useState('');
    const [price, setPrice] = useState('');
    const [availableQuantity, setAvailableQuantity] = useState('');
    const [description, setDescription] = useState('');
    const [urlImage, setUrlImage] = useState('');

    const [products, setProducts] = useState([]);

    const url = 'https://localhost:5001/api'

    useEffect(() => {
        listarProdutos();
    }, []);

    const listarProdutos = () => {
        fetch(`${url}/get-all-products/`)
            .then(response => response.json())
            .then(data => {
                setProducts(data.data)
                limparCampos();
            })
            .catch(err => console.error(err));
    }

    const limparCampos = () => {
        setId(0);
        setName('');
        setDescription('');
        setPrice(0);
        setUrlImage('');
        setAvailableQuantity('');
    }

    const salvar = (event) => {
        event.preventDefault();

        const product = {
            name : name,
            price: price,
            availableQuantity: availableQuantity,
            description : description,
            urlImage: urlImage,
        }

        let method = (id === 0 ? 'POST' : 'PUT');
        let urlRequest = (id === 0 ? `${url}/add-product/` : `${url}/edit-product/${id}`);

        fetch(urlRequest, {
            method : method,
            body : JSON.stringify(product),
            headers : {
                'content-type' : 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            addToast('Produto cadastrado!', { appearance: 'success' });

            listarProdutos();
        })
        .catch(err => {
            console.error(err)
            addToast('Algo inesperado aconteceu!', { appearance: 'error' });
        })
    }

    const editar = (event) => {
        event.preventDefault();

        fetch(`${url}/search-product/${event.target.value}`, {
            method : 'GET'
        })
        .then(response => response.json())
        .then(dado => {
            setId(dado.id)
            setName(dado.name);
            setPrice(dado.price);
            setDescription(dado.description);
            setUrlImage(dado.urlImage);
            setAvailableQuantity(dado.availableQuantity);
        })
    }

    const remover = (event) => {
        event.preventDefault();

        fetch(`${url}/delete-product/${event.target.value}`, {
            method : 'DELETE',
        })
        .then(response => response.json())
        .then(dados => {
            addToast('Produto removido!', { appearance: 'success' });

            listarProdutos();
        })
    }

    return (
        <div>
            <Header />
            <div className="dashboard-content">
                <Container style={{marginTop: '20px', fontFamily: 'Poppins'}}>
                    <Card>
                        <Card.Body>
                            <Form onSubmit={event => salvar(event)}>
                                <Form.Group controlId="formBasicNome">
                                    <Form.Label>Nome</Form.Label>
                                    <Form.Control type="text" value={name} onChange={event => setName(event.target.value)} placeholder="Nome do produto"></Form.Control>
                                </Form.Group>
                                <Form.Group controlId="formBasicLink" style={{marginTop: '20px'}}>
                                    <Form.Label>Preço (R$)</Form.Label>
                                    <Form.Control type="number" value={price} onChange={event => setPrice(event.target.value)} placeholder="Valor do produto (R$)"></Form.Control>
                                </Form.Group>
                                <Form.Group controlId="formBasicLink" style={{marginTop: '20px'}}>
                                    <Form.Label>URL da Imagem</Form.Label>
                                    <Form.Control type="text" value={urlImage} onChange={event => setUrlImage(event.target.value)} placeholder="URL da Imagem do produto"></Form.Control>
                                </Form.Group>
                                <Form.Group controlId="formBasicLink" style={{marginTop: '20px'}}>
                                    <Form.Label>Quantidade disponível</Form.Label>
                                    <Form.Control type="text" value={availableQuantity} onChange={event => setAvailableQuantity(event.target.value)} placeholder="Quantidade em estoque"></Form.Control>
                                </Form.Group>
                                
                                <Form.Group controlId="formBasicUrl" style={{marginTop: '20px'}}>
                                    <Form.Label>Descrição</Form.Label>
                                    <Form.Control as="textarea" value={description} onChange={event => setDescription(event.target.value)} placeholder="Descreva o produto"/>
                                </Form.Group>
                                <Button type="submit" style={{marginTop: '20px'}}>Salvar</Button>
                            </Form>
                        </Card.Body>
                    </Card>

                    <Table striped bordered hover className="tabela">
                        <thead >
                            <tr>
                                <th>Nome</th>
                                <th>Preço (R$)</th>
                                <th>Quantidade disponível</th>
                                <th>Ações</th>
                            </tr>
                        </thead>
                        <tbody>
                        {
                                products.map((item, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{item.name}</td>
                                            <td className="tdDisable">{item.price}</td>
                                            <td className="tdDisable">{item.availableQuantity}</td>
                                            <td>
                                                <Button variant="warning" value={item.id} onClick={event => editar(event)} >Editar</Button>
                                                <Button variant="danger" value={item.id} onClick={event => remover(event)} style={{ marginLeft : '20px'}}>Remover</Button>
                                            </td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </Table>
                </Container>
            </div>
        </div>
    )
}

export default Dashboard;
