import Notes from "@/components/Notes";

export default function NotesLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return (
        <section className="flex">
            <Notes />
            {children}
        </section>
    );
}