import { useContext, useEffect, useState } from "react"
import Header from "../components/Header"
import styles from "./Produtos.css"
import { useNavigate } from "react-router-dom"
import {ProductContext} from "../contexts/productContext"
import useFetch from "../hooks/useFetch"

function Produtos(){


    //const [products, setProducts] = useState();
    
    const [data, request] = useFetch("http://localhost:3001/products")
    const productContext = useContext(ProductContext)
    productContext.setProduct(data)

    const navigate = useNavigate()

    useEffect(()=>{

        request()
        // const fetchProducts = async() =>{
        // const result  = await fetch("http://localhost:3001/products") 
        // const products = await result.json()
        // setData(products)
        // productContext.setProducts(products)
        // }
        // fetchProducts()
        
    }, [request])

    function handleClick(id){
        navigate(`${id}`)
    }


    return(
        
        <div>
            <Header/>
            <h1>Produtos</h1>
            <div className="containerProdutos">
                {data && data.map((product) =>{
                    return <div className="cardProduto" onClick={() => handleClick(product.id)} > 
                    <img src={product.photo_url} alt=""/> 
                    <h1>{product.name}</h1>
                    <p>R${product.price}</p>
                    </div>
                })}
            </div> 
        </div>
    )
}

export default Produtos;