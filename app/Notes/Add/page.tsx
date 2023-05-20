'use client'

import React, { useState } from 'react'

export default function page() {
    const [title, setTitle] = useState<string>("")
    const [content, setContent] = useState<string>("")
    const [data, setData] = useState<any>({ title: "", content: "" })

    const handleSubmit = (e: any) => {
        e.preventDefault()
        setData({ title: title, content: content })


    }

    return (
        <div>
            <form onSubmit={e => handleSubmit(e)}>
                <input
                    className="border w-20 h-14 m-5"
                    placeholder="add title"
                    value={title}
                    onChange={e => setTitle(e.target.value)}
                />
                <input
                    className="border w-30 h-14 m-5"
                    placeholder="add content"
                    value={content}
                    onChange={e => setContent(e.target.value)}
                />
                <button type='submit'>sent</button>
            </form>
            <div>{data.title}</div>
            <div>{data.content}</div>
        </div>
    )
}
