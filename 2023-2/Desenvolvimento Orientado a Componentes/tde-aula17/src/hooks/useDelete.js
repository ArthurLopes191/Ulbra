import { useCallback, useState } from "react"

async function useDelete({ produto, onDelete }) {
    const response = await fetch('http://localhost:3001/products', {
        method: 'DELETE',
        headers: {
        'Content-Type': 'application/json',
        },
    });

    
}

export default useDelete