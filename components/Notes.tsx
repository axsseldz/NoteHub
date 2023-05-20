import { FaSort } from 'react-icons/fa'
import { FiSearch } from 'react-icons/fi'
import { AiFillPlusCircle } from 'react-icons/ai'
import SingleNote from './SingleNote';
import Link from 'next/link';

type PageProps = {
    data: any
}


export default function Notes({ data }: PageProps) {

    return (
        <div className="bg-white-dusk border min-w-[435px] h-screen pb-5 pt-10">
            <div className='flex justify-between p-6 h-24'>
                <h1 className='text-2xl'>All Notes</h1>
                <div className='flex space-x-2'>
                    <FaSort className='icon' />
                    <FiSearch className='icon' />
                </div>
            </div>
            <div className='flex flex-col h-4/6 overflow-y-auto'>
                {data.map((note: any) => (
                    <Link href={`/Notes/${note.id}`}>
                        <SingleNote data={note} />
                    </Link>
                ))}
            </div>
            <Link href="/Notes/Add">
                <div className='h-20 flex items-center space-x-2 justify-center border-4 border-dashed rounded-md m-10 mt-10 p-5 cursor-pointer hover:shadow-lg'>
                    <AiFillPlusCircle className='icon' />
                    <p>Add New Note</p>
                </div>
            </Link>
        </div>
    )
}
