'use client'

import Link from 'next/link';
import React, { useState } from 'react'
import { MdDeleteForever } from 'react-icons/md'


const deleteNote = async (id: any) => {
    try {
        const response = await fetch(`http://localhost:5123/api/TodoList/${id}`, {
            method: 'DELETE'
        });

        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

type PageProps = {
    id: any
}

export default function Note({ id }: PageProps) {
    const handleClick = async () => {
        await deleteNote(id);
    };

    return (
        <Link href="/Notes">
            <div onClick={handleClick} className='hover:bg-red-600 hover:text-white text-red-600 rounded-full p-1'>
                <MdDeleteForever className='text-2xl cursor-pointer' />
            </div>
        </Link>
    )
}
