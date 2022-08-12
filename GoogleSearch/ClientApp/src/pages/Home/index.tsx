import * as React from 'react';
import "./index.css";
import { FaSearch } from "react-icons/fa";
import { SearchGoogle } from "../../api/api"
import * as requests from '../../interfaces/IRequest';

export default function Home() {
    const [valueSearchInput, setValueSearchInput] = React.useState("");
    const [resources, setResources] = React.useState<requests.IItem[]>([]);
    const [existResource, setExistResource] = React.useState<boolean>(true);

    //Pesquise o texto no google e retorna a resposta e paginação
    function SearchGoogleRequest() {
        if (valueSearchInput)
            SearchGoogle(valueSearchInput, "")
                .then((data) => {

                    if (data.items.length > 0) {
                        setResources(data.items)
                        setExistResource(true);
                    } else {
                        setResources([])
                        setExistResource(false);
                    }
                })
                .catch((err) => {
                    console.log(err)
                });
    }

    return (
        <div className="container">
            <div className="items">
                <div className="items-head">
                    <ul>
                        <li>
                            <p>Google</p>
                        </li>
                        <li>
                            <input className='searchInput' type="text" placeholder="Search.." name="search2"
                                onChange={(e) => setValueSearchInput(e.target.value)} value={valueSearchInput} /></li>
                        <li>
                            <button className='searchButton' type="submit" onClick={SearchGoogleRequest} ><FaSearch /></button></li>
                    </ul>
                    {(resources.length > 0 || existResource === false) &&

                        <hr />
                    }
                </div>

                <div className="items-body">
                    {existResource ?
                        <> {
                            resources.map((resource) =>
                                <div className="items-body-content">
                                    <span >{resource.title}</span><br />
                                    <span className='link'><a href={resource.link}>{resource.link}</a> </span>
                                </div>
                            )
                        } </>
                        :
                        <>Sua pesquisa não encontrou nenhum documento correspondente</>
                    }

                </div>
            </div>
        </div>
    );
}
