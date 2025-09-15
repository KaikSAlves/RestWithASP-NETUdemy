#!/bin/bash
set -e

for i in $(find /home/database/ -name "*.sql" | sort --version-sort); do
  echo "Executando migration: $i"
  mysql -uroot -pdocker rest_with_asp_net_udemy < "$i"
done
