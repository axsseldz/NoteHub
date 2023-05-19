import Notes from "@/components/Notes";

const getNotes = async () => {
    const response = await fetch('http://localhost:5123/api/TodoList/GetAll?timestamp=' + Date.now());
    const data = await response.json();
    return data.data
}


export default async function NotesLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    const data = await getNotes();
    console.log(data)

    return (
        <section className="flex">
            <Notes data={data} />
            {children}
        </section>
    );
}