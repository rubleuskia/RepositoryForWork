import { useState, useEffect } from "react";
import { Pagination, Alert, Spinner, Col, Nav, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { fetchTopFilms } from "../../services/topFilmsService";
import FilmDTO from "../../types/films";
import Film from "../general/film";



const TopFilms = () => {

    let activePage = 1;

    function PageUp() {
        activePage += 1;
    }

    function PageDown() {
        activePage -= 1;
    }
    const [films, setFilms] = useState<FilmDTO[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        fetchTopFilms(activePage).then((films) => {
            setFilms(films);
            setError("")
        })
            .catch((e: Error) => setError(e.message));
    }, [activePage]);

    return (
        <>
            <div className="row row-cols-1 row-cols-sm-2 row-cols-md3 g-3 p-1 m-2">
                {error && <Alert variant='danger'>Falled to fetch</Alert>}
                {!error && films.length === 0 && <Spinner animation="border" variant="primary" />}
                <Col xs lg="2"></Col>
                <Col>
                    {films.length > 0 && films.map((film) =>
                        <Film posterUrlPreview={film.posterUrlPreview} webUrl={film.webUrl} nameRu={film.nameRu} filmId={film.filmId} description={film.description} kinopoiskRating={film.kinopoiskRating} />)}
                </Col>
                <Col></Col>

                <Nav>
                    <Button variant="primary" size="lg" onClick={() => PageDown} disabled={activePage === 1}>Назад</Button>
                    <Button variant="primary" size="lg" onClick={() => PageUp} disabled={activePage === 13}>Вперёд</Button>
                </Nav>
            </div>

        </>

    );
}

export default TopFilms;