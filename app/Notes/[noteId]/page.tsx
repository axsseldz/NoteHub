import { AiFillCaretDown, AiOutlineBold, AiOutlineUnderline, AiOutlineUpload } from 'react-icons/ai'
import { BsJustifyLeft, BsJustifyRight, BsReverseListColumnsReverse, BsFillFileEarmarkRichtextFill } from 'react-icons/bs'
import { CiBoxList } from 'react-icons/ci'
import { MdDateRange } from 'react-icons/md'
import transformDateTime from '@/functions/DateTime'
import Note from '@/components/Note'

const getData = async (id: any) => {
    const response = await fetch(`http://localhost:5123/api/TodoList/${id}?timestamp=' + Date.now()`);
    const data = await response.json();
    console.log(data.data)
    return data.data

}

type PageProps = {
    params: {
        noteId: string
    }
}

export default async function NotePage({ params: { noteId } }: PageProps) {
    const data = await getData(noteId);
    const date = transformDateTime(data.createdDate)

    if (!data) {
        return (
            <div className="min-w-[748px]">
                <h1>Not available</h1>
            </div>
        );
    }


    return (
        <div className="min-w-[748px]">
            <div className="w-[650px] h-100 mx-auto mt-14">
                <div className="flex items-center justify-start p-3 w-[100%] space-x-4 border-b-2">
                    <div className="flex items-center justify-center space-x-1">
                        <p>25</p>
                        <AiFillCaretDown className='text-sm text-gray-300' />
                    </div>
                    <p className='text-gray-300 text-2xl'>|</p>

                    <AiOutlineBold className='text-lg' />

                    <AiOutlineUnderline className='text-lg' />

                    <p className='text-gray-300 text-2xl'>|</p>

                    <BsJustifyLeft className='text-lg' />

                    <BsJustifyRight className='text-lg' />

                    <div className="flex items-center justify-center space-x-1">
                        <BsReverseListColumnsReverse className='text-lg' />
                        <AiFillCaretDown className='text-sm text-gray-300' />
                    </div>

                    <p className='text-gray-300 text-2xl'>|</p>

                    <CiBoxList className='text-lg' />

                    <AiOutlineUpload className='text-lg' />
                </div>
                <div className='flex flex-col space-y-2 p-3'>
                    <div className='flex items-center justify-between py-2'>
                        <h1 className='text-2xl'>{data.title}</h1>
                        <Note id={noteId} />
                    </div>
                    <div className='flex items-center space-x-1'>
                        <MdDateRange className='text-lg' />
                        <p className='text-sm text-gray-400'>{date}</p>
                    </div>
                </div>
                <div className='flex flex-col  space-y-2 bg-light-green rounded-md p-3 mt-4'>
                    <div className='bg-custom-yellow text-white flex items-center justify-center w-7 rounded-full p-1'>
                        <BsFillFileEarmarkRichtextFill className='text-xl' />
                    </div>
                    <div className='text-white px-2'>{data.content}</div>
                </div>
            </div>
        </div>
    )
}
