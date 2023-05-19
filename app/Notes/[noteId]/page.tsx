import { useRouter } from 'next/router'

type PageProps = {
    params: {
        noteId: string
    }
}

export default function NotePage({ params: { noteId } }: PageProps) {


    return (
        <div>{noteId}</div>
    )
}
