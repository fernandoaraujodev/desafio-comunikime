import React, { useEffect, useState } from 'react'
import './styles.css'
import '../../../node_modules/bootstrap/dist/css/bootstrap.min.css';
import ItemCard from '../../components/itemCard';
import Header from '../../components/header';

const Store = () => {
    const [items, setItems] = useState([])

    useEffect(() => {
        getItems()
    }, [])

    const getItems = () => {
        fetch('https://localhost:5001/api/get-all-products')
            .then(response => response.json())
            .then(data => {
                setItems(data.data)
            })
            .catch(err => console.error(err));
    }

    return(
        <div>
            <Header />
            <div className="main-content">
                <div className="side-filters">
                
                </div>

                <div className="main-items">
                    <div className="filters">

                    </div>

                    <div className="cards">
                        {
                            items.map((item, index) => {
                                return(
                                    <ItemCard key={item.id} item={item} />
                                )
                            })
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Store;