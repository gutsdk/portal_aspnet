import React from 'react'
import { Link } from 'react-router-dom'

export default class Header extends React.Component {
    render() {
        return (
            <header>
                <menu>
                    <ui>
                        <li>
                            <Link to="/">Blog</Link>
                        </li>
                        <li>
                            <Link to="/about">About me</Link>
                        </li>
                    </ui>
                </menu>
            </header>
        )
    }
}