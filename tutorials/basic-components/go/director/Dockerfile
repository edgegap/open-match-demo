FROM golang:1.15

COPY . /go/src/app
WORKDIR /go/src/app

RUN go get -d -v /go/src/app
RUN go install -v /go/src/app

WORKDIR /go/bin 

CMD ["director"]