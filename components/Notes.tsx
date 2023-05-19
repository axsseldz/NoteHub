import { FaSort } from 'react-icons/fa'
import { FiSearch } from 'react-icons/fi'
import { AiFillPlusCircle } from 'react-icons/ai'
import SingleNote from './SingleNote';


const getNotes = async () => {
    const response = await fetch('http://localhost:5123/api/TodoList/GetAll?timestamp=' + Date.now());
    const data = await response.json();
    return data.data
}

export default async function Notes() {
    const data = await getNotes();
    console.log(data)

    return (
        <div className="bg-white-dusk border w-100 h-screen pb-5 pt-10">
            <div className='flex justify-between p-6 h-24'>
                <h1 className='text-2xl font-bold'>All Notes</h1>
                <div className='flex space-x-2'>
                    <FaSort className='icon' />
                    <FiSearch className='icon' />
                </div>
            </div>
            <div className='flex flex-col h-4/6 overflow-y-auto'>
                {data.map((note: any) => (
                    <SingleNote data={note} />
                ))}
            </div>
            <div className='h-20 flex items-center justify-center border-4 border-dashed rounded-md m-10 mt-10 p-5'>
                <AiFillPlusCircle className='icon' />
                <p>Add New Note</p>
            </div>
        </div>
    )
}
