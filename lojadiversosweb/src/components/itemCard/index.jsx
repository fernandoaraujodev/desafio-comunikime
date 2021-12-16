import React, { useState } from 'react'

import './styles.css'

//toast
import { useToasts } from 'react-toast-notifications';

const ItemCard = (itemSale) => {
    const {addToast} = useToasts();

    const [availableQuantity, setAvailableQuantity] = useState(0)
    const [buyButton, setBuyButton] = useState('buyButtonDisabled')
    const [disabledButton, setDisabledButton] = useState(true)

    const changeQuantity = (event, operation) => {
        event.preventDefault();

        if(availableQuantity - 1 === 0){
            setBuyButton('buyButtonDisabled')
            setDisabledButton(true)
        }
        
        if(operation === "-" && availableQuantity > 0){
            return setAvailableQuantity(availableQuantity - 1)
        }
        else if(operation === "+" && availableQuantity < itemSale.item.availableQuantity){
            setBuyButton('buyButton')
            setDisabledButton(false)
            
            return setAvailableQuantity(availableQuantity + 1)
        }
    }

    
    const buyItem = (event, id) => {
        event.preventDefault()

        fetch('https://localhost:5001/api/buy-product/' + id + '?availableQuantity=' + availableQuantity, {
            method: 'POST',
        })
            .then(response => response.json())
            .then(data => {
                addToast('Compra efetuada!', { appearance: 'success' });

                window.location.reload();
            })
            .catch(err => console.error(err));
    }

    return (
        <div className="card-content">
            <img src={itemSale.item.urlImage} alt="Imagem do produto" />

            <div className="card-description">
                <div>
                    <h2>{itemSale.item.name}</h2>
                </div>

                <div className="price">
                    <h2>R$ {itemSale.item.price}</h2>
                </div>
            </div>

            <div className="buy">
                <div className="quantity">
                    <h4>Em estoque: {itemSale.item.availableQuantity}</h4>
                    <div className="quantity-button">
                        <button onClick={e => changeQuantity(e, "-")}> - </button>
                        <h2>{availableQuantity}</h2>
                        <button onClick={e => changeQuantity(e, "+")}> + </button>
                    </div>
                </div>

                <div className="buy-btn">
                <button id="Button" className={buyButton} disabled={disabledButton} onClick={e => buyItem(e, itemSale.item.id)}>
                    <p>Comprar</p>
                </button>
                </div>
            </div>
        </div>
    )
}

export default ItemCard