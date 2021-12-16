import React, { Component } from 'react'
import './styles.css'

const Header = () => {
    return (
        <div className="menu">
            <div className="menu-content">
                
                <div className="links">
                    <a href="/dashboard">
                        <div className="options-header">
                            <h4>Dashboard</h4>
                        </div>
                    </a>
                    <div className="logo">
                        <h3>Comuniki.me</h3>
                    </div>
                    <a href="/store">
                        <div className="options-header">
                            <h4>Store</h4>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    )
    
}

export default Header
