import React, { useState } from 'react';
import styles from "./Formulario.css"

function Formulario() {

  return (
    <div className='container'>
   

    <form className='form-container'>
      <h1>Novo Cliente</h1>
      <h3>Nome</h3>
      <input className='input-data' type="text" placeholder="Nome"/>

      <h3>Email</h3>
      <input className='input-data' type="email" placeholder="Email"/>

      <h3>Telefone</h3>
      <input className='input-data' type="tel" placeholder="Telefone"/>

      <h3>Cidade</h3>
      <input className='input-data' type="text" placeholder="Cidade"/>
      
      
      
      <button className='buttonEnviar' type="submit">Cadastrar</button>
    </form>
    </div>
  );
}

export default Formulario;
